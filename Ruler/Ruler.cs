// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

// TODO: Do portals, black holes and rebound walls. Do GUI for control this objects by mouse. Do auto set value of wind, auto setup objects and user tank position.
// TODO: Дописать порталы и черные дыры. Добавить предустановленные режимы экрана. Сделать дебаг-мод. Сделать стены. Сделать графический интерфейс. Переделать с рисования на рендеринг с фпс. [Maybe] Сделать автоопределение ветра, автонаводку, автоопределение позиции танка, автоустановку объектов, поиск оптимального пути снаряда.
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Ruler.Properties;
using Common;

namespace Ruler
{
    public static class Functions
    {
        public static Int32 LimitToRange(
            this Int32 value, Int32 inclusiveMinimum, Int32 inclusiveMaximum, Boolean reverse = false)
        {
            if (value < inclusiveMinimum) { return reverse ? inclusiveMaximum : inclusiveMinimum; }
            if (value > inclusiveMaximum) { return reverse ? inclusiveMinimum : inclusiveMaximum; }
            return value;
        }
    }
    public class Ruler : Form
    {
        public Boolean IsDebugged, IsDisguise = false;
        private Licence licence;
        private readonly IContainer components = null;
        private Int32 ph, angle, power, wind, guidanceMode;
        private Double gravity, velocity, radius, windw;
        private (Int32 X, Int32 Y, Int32 Radius) sight, blackHole;
        private ((Int32 X, Int32 Y) FirstPortal, (Int32 X, Int32 Y) SecondPortal, Int32 Radius) portal;
        private Point point;
        private readonly RulerLocalization localization;
        private const Int32 MaxGuidanceMode = 1;
        private const Int32 Alt = 1, Ctrl = 2, Shift = 4;
        private const Int32 SightUp = 1, SightDown = 2, SightLeft = 3, SightRight = 4, AimQuit = 5, AngleLeft = 6, AngleRight = 7, PowerUp = 8, PowerDown = 9, SetSightPosition = 10, AimReset = 11, SetWind = 12, SetAngle = 13, SetPower = 14, SetRadius = 15, ChangeGuidanceMode = 16, SightUpShift = 31, SightDownShift = 32, SightLeftShift = 33, SightRightShift = 34, AimQuitShift = 35, AngleLeftShift = 36, AngleRightShift = 37, PowerUpShift = 38, PowerDownShift = 39, SetSightPositionShift = 40, AimResetShift = 41, SetWindShift = 42, SetAngleShift = 43, SetPowerShift = 44, SetRadiusShift = 45, ChangeGuidanceModeShift = 46, SetPortalRadius = 60, SetFirstPortal = 61, SetSecondPortal = 62, ResetPortals = 63, SetBlackHoleRadius = 64, SetBlackHole = 65, SetBlackHoleShift = 66, ResetBlackHole = 67;
        private const Double ProgramVersion = 0.78;
        private static readonly Dictionary<String, (Int32 Length, Int32 PointHeight, Double Gravity, Double Velocity, Double Radius, Double WindW, Int32 PortalRadius, Int32 BlackHoleRadius)> Resolutions = new Dictionary<String, (Int32 Length, Int32 PointHeight, Double gravity, Double Velocity, Double Radius, Double WindW, Int32 PortalRadius, Int32 BlackHoleRadius)>
        {
            {"1280x1024", (220, 145, 9.8d, 1.272d, 19.9d, 1.0d/80.0d, 50, 50)},
            {"1366x768", (236, 145, 9.8d, 1.317d, 20.0d, 1.0d/80.0d, 50, 50)},
            {"1600x1024", (280, 145, 9.8d, 1.424d, 22.8d, 1.0d/80.0d, 50, 50)},
            {"1680x1050", (300, 145, 9.8d, 1.46d, 26.0d, 1.0d/80.0d, 50, 50)},
            {"1920x1080", (300, 165, 9.8d, 1.559d, 28.0d, 1.0d/80.0d, 50, 50)}, //can't check params
            {"2560x1440", (350, 240, 9.8d, 1.8d, 37.0d, 1.0d/80.0d, 50, 50)} //can't check params
        };
        private (Int32 Length, Int32 PointHeight, Double Gravity, Double Velocity, Double Radius, Double WindW, Int32 PortalRadius, Int32 BlackHoleRadius) Resolution = Resolutions["1366x768"];
        private Label labelPower, labelAngle, labelWind;
        [DllImport("user32.dll")]
        private static extern Boolean RegisterHotKey(IntPtr hWnd, Int32 id, Int32 fsModifiers, Int32 vlc);
        // [DllImport("user32.dll")]
        // private static extern Boolean UnregisterHotKey(IntPtr hWnd, Int32 id);

        [DllImport("user32.dll")]
        private static extern Int32 SetWindowText(IntPtr hWnd, String text);

        protected override Boolean ProcessDialogKey(Keys keyData)
        {
            if (ModifierKeys != Keys.None || keyData != Keys.Escape)
                return base.ProcessDialogKey(keyData);
            Close();
            return true;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 33554432;
                return createParams;
            }
        }
        internal Ruler(Licence licence, String languageCode = null, Boolean isDisguise = false)
        {
            IsDisguise = isDisguise;
            this.licence = licence;
            localization = languageCode != null ? new RulerLocalization(languageCode) : new RulerLocalization();
            if (IsDisguise)
            {
                SetWindowText(Handle, "notepad.exe");
            }

            RegisterHotKey(Handle, SightUp, Ctrl, 'W');
            RegisterHotKey(Handle, SightLeft, Ctrl, 'A');
            RegisterHotKey(Handle, SightDown, Ctrl, 'S');
            RegisterHotKey(Handle, SightRight, Ctrl, 'D');
            RegisterHotKey(Handle, AimQuit, Ctrl, 'Q');
            RegisterHotKey(Handle, SightUpShift, Ctrl+Shift, 'W');
            RegisterHotKey(Handle, SightLeftShift, Ctrl+Shift, 'A');
            RegisterHotKey(Handle, SightDownShift, Ctrl+Shift, 'S');
            RegisterHotKey(Handle, SightRightShift, Ctrl+Shift, 'D');
            RegisterHotKey(Handle, AimQuitShift, Ctrl+Shift, 'Q');
            RegisterHotKey(Handle, AngleLeft, Ctrl, '\'');
            RegisterHotKey(Handle, AngleRight, Ctrl, '%');
            RegisterHotKey(Handle, PowerUp, Ctrl, '&');
            RegisterHotKey(Handle, PowerDown, Ctrl, '(');
            RegisterHotKey(Handle, AngleLeftShift, Ctrl+Shift, '\'');
            RegisterHotKey(Handle, AngleRightShift, Ctrl+Shift, '%');
            RegisterHotKey(Handle, PowerUpShift, Ctrl+Shift, '&');
            RegisterHotKey(Handle, PowerDownShift, Ctrl+Shift, '(');
            RegisterHotKey(Handle, SetSightPosition, Ctrl, 'E');
            RegisterHotKey(Handle, AimReset, Ctrl, 'Z');
            RegisterHotKey(Handle, SetWind, Ctrl, 'F');
            RegisterHotKey(Handle, SetAngle, Ctrl, 'G');
            RegisterHotKey(Handle, SetPower, Ctrl, 'H');
            RegisterHotKey(Handle, SetRadius, Ctrl, 'R');
            RegisterHotKey(Handle, ChangeGuidanceMode, Ctrl, 'M');
            RegisterHotKey(Handle, SetSightPositionShift, Ctrl+Shift, 'E');
            RegisterHotKey(Handle, AimResetShift, Ctrl+Shift, 'Z');
            RegisterHotKey(Handle, SetWindShift, Ctrl+Shift, 'F');
            RegisterHotKey(Handle, SetAngleShift, Ctrl+Shift, 'G');
            RegisterHotKey(Handle, SetPowerShift, Ctrl+Shift, 'H');
            RegisterHotKey(Handle, SetRadiusShift, Ctrl+Shift, 'R');
            RegisterHotKey(Handle, ChangeGuidanceModeShift, Ctrl+Shift, 'M');
            RegisterHotKey(Handle, SetPortalRadius, Ctrl+Alt, 'P');
            RegisterHotKey(Handle, SetFirstPortal, Ctrl, 'P');
            RegisterHotKey(Handle, SetSecondPortal, Ctrl+Shift, 'P');
            RegisterHotKey(Handle, ResetPortals, Ctrl+Alt+Shift, 'P');
            RegisterHotKey(Handle, SetBlackHoleRadius, Ctrl+Alt, 'B');
            RegisterHotKey(Handle, SetBlackHole, Ctrl, 'B');
            RegisterHotKey(Handle, SetBlackHoleShift, Ctrl+Shift, 'B');
            RegisterHotKey(Handle, ResetBlackHole, Ctrl+Alt+Shift, 'B');
            InitializeComponent();
        }

        private void Main_Form_Init(Object sender = null, EventArgs e = null)
        {
            sight = (X : Width / 2, Y : Height / 2, Radius : Resolution.Length);
            guidanceMode = 0;
            angle = 85;
            power = 100;
            wind = 0;
            gravity = Resolution.Gravity;
            velocity = Resolution.Velocity; //velocity?
            radius = Resolution.Radius;
            windw = Resolution.WindW; //(wind what?)
            ph = Resolution.PointHeight; //point height?
            portal.FirstPortal.X = portal.FirstPortal.Y = portal.SecondPortal.X = portal.SecondPortal.Y = blackHole.X = blackHole.Y = 0;
            portal.Radius = blackHole.Radius = 50;
            labelPower.Text = $@"{power}%";
            labelAngle.Text = $@"{angle}°";
            labelWind.Text = $@"{wind}";
        }

        private void Main_Form_Paint(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Pen pen;
            //Font font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, (Byte)204);
            for (Int32 circleAngle = 0; circleAngle < 360; circleAngle += 45)
            {
                if (circleAngle % 90 == 0) pen = Pens.Red;
                else if (circleAngle % 60 == 0) pen = Pens.Yellow;
                else if (circleAngle % 45 == 0) pen = circleAngle < 180 ? Pens.Aquamarine : Pens.Blue;
                else if (circleAngle % 30 == 0) pen = Pens.GreenYellow;
                else if (circleAngle % 15 == 0) pen = circleAngle < 180 ? Pens.Orange : Pens.Brown;
                else pen = Pens.DarkGray;
                Single sin = sight.Radius * (Single) Math.Sin(Math.PI * circleAngle / 180f) * 1.05f;
                Single cos = sight.Radius * (Single) Math.Cos(Math.PI * circleAngle / 180f) * 1.05f;
                graphics.DrawLine(pen, sight.X, sight.Y, sight.X+ cos, sight.Y - sin);
            }
            for (Int32 circleRange = 25; circleRange <= 100; circleRange += 25)
            {
                if (circleRange % 100 == 0) pen = Pens.LightCoral;
                else if (circleRange % 75 == 0) pen = Pens.LightGoldenrodYellow;
                else if (circleRange % 50 == 0) pen = Pens.LightGreen;
                else if (circleRange % 25 == 0) pen = Pens.LightSeaGreen;
                else if (circleRange % 10 == 0) pen = Pens.DarkBlue;
                else pen = Pens.DarkGray;
                graphics.DrawEllipse(pen, sight.X - (sight.Radius * circleRange / 100f), sight.Y - (sight.Radius * circleRange / 100f), sight.Radius * (2f * circleRange / 100f), sight.Radius * (2f * circleRange / 100f));
            }
            graphics.DrawLine(Pens.Red, sight.X, sight.Y, sight.X + sight.Radius * (Single)Math.Cos(Math.PI * angle / 180f) * power / 100f, sight.Y - sight.Radius * (Single)Math.Sin(Math.PI * angle / 180f) * power / 100f);
            SolidBrush brush = new SolidBrush(Color.FromArgb(15, 220, 15));
            graphics.FillEllipse((Brush) brush, sight.X - 4, sight.Y - 4, 8, 8);
            //graphics.DrawString("Made by Rain0Ash", font, Brushes.Azure, Width / 10, 0);
            Double floatAngle = (Double) angle * (Math.PI / 180.0);
            Single floatAngleSin = (Single)Convert.ToInt16(radius * Math.Sin(floatAngle));
            Single floatAngleCos = (Single) Convert.ToInt16(radius * Math.Cos(floatAngle));
            brush.Color = Color.White;
            Single counter = 0.0f;
            Boolean portalCheck = true;
            Single _x = sight.X;
            Single _y = sight.Y;
            Int32 portalCounter = 0;
            while ((Double) counter < 60.0)
            {
                switch (guidanceMode)
                {
                    case 0:
                    {
                        point.X = Convert.ToInt32((Double) _x + 
                                                  ((Double) power * velocity * (Double) counter * Math.Cos(floatAngle)) +
                                                  (0.5 * (Double) wind * windw * (Double) counter * (Double) counter));
                        point.Y = Convert.ToInt32((Double) _y -
                                                  ((Double) power * velocity * (Double) counter * Math.Sin(floatAngle)) +
                                                  (0.5 * gravity * (Double) counter * (Double) counter));
                        if ((Double)point.Y <= (Double)(Height - ph))
                        {
                            graphics.FillEllipse((Brush)brush, (Single)((Double)point.X + (Double)floatAngleCos - 1.0), (Single)((Double)point.Y - (Double)floatAngleSin - 1.0), 2f, 2f);
                        }
                        counter += 0.05f;
                        break;
                    }
                    case 1:
                    {
                        point.X = (Int32) (_x + sight.Radius * (Single)Math.Cos(Math.PI * angle / 180f) * counter);
                        point.Y = (Int32) (_y - sight.Radius * (Single)Math.Sin(Math.PI * angle / 180f) * counter);
                        graphics.FillEllipse((Brush)brush, point.X, point.Y, 2f, 2f);
                        counter += 0.03f;
                        break;
                    }
                    default:
                    {
                        guidanceMode = 0;
                        break;
                    }
                }

                if (portal.Radius > 0 && portal.FirstPortal.X > 0 && portal.FirstPortal.Y > 0 && portal.SecondPortal.X > 0 && portal.SecondPortal.Y > 0)
                {
                    Boolean firstPortalIntersection = (Math.Sqrt(Math.Pow(portal.FirstPortal.X - point.X-Math.Sqrt(portal.Radius) / 2, 2) + Math.Pow(portal.FirstPortal.Y - point.Y+ Math.Sqrt(portal.Radius) / 2, 2)) < (Double) portal.Radius / 2);
                    Boolean secondPortalIntersection = (Math.Sqrt(Math.Pow(portal.SecondPortal.X - point.X - Math.Sqrt(portal.Radius) / 2, 2) + Math.Pow(portal.SecondPortal.Y - point.Y+ Math.Sqrt(portal.Radius) / 2, 2)) < (Double) portal.Radius / 2);
                    if (portalCheck && (firstPortalIntersection ^ secondPortalIntersection) && portalCounter < 3)
                    {
                        _x = (firstPortalIntersection ? portal.SecondPortal.X : portal.FirstPortal.X) - ((firstPortalIntersection ? portal.FirstPortal.X : portal.SecondPortal.X) - sight.X);
                        _y = (firstPortalIntersection ? portal.SecondPortal.Y : portal.FirstPortal.Y) - ((firstPortalIntersection ? portal.FirstPortal.Y : portal.SecondPortal.Y) - sight.Y);
                        portalCounter += 1;
                        portalCheck = false;
                    }
                    if (!portalCheck && !(firstPortalIntersection || secondPortalIntersection))
                    {
                        portalCheck = true;
                    }
                }
                
                if (blackHole.Radius > 0 && blackHole.X > 0 && blackHole.Y > 0)
                {
                    Boolean blackHoleEventHorizonIntersection = (Math.Sqrt(Math.Pow(blackHole.X - point.X, 2) + Math.Pow(blackHole.Y - point.Y, 2)) < (Double) blackHole.Radius / 2);
                    Boolean blackHoleGravityRadiusIntersection = (Math.Sqrt(Math.Pow(blackHole.X - point.X, 2) + Math.Pow(blackHole.Y - point.Y, 2)) < (Double) blackHole.Radius * 2);
                    if (blackHoleEventHorizonIntersection)
                    {
                        break;
                    }
                    else if (blackHoleGravityRadiusIntersection)
                    {
                        gravity = -Math.Abs(gravity);
                    }
                    else
                    {
                        gravity = Math.Abs(gravity);
                    }
                }

            }
            if (portal.Radius > 0)
            {
                if (portal.FirstPortal.X > 0 && portal.FirstPortal.Y > 0)
                {
                    graphics.DrawEllipse(Pens.CornflowerBlue, portal.FirstPortal.X-portal.Radius / 2, portal.FirstPortal.Y-portal.Radius / 2, portal.Radius, portal.Radius);
                }
                if (portal.SecondPortal.X > 0 && portal.SecondPortal.Y > 0)
                {
                    graphics.DrawEllipse(Pens.Orange, portal.SecondPortal.X-portal.Radius / 2, portal.SecondPortal.Y-portal.Radius / 2, portal.Radius, portal.Radius);
                }

            }

            if (blackHole.Radius > 0 && blackHole.X > 0 && blackHole.Y > 0)
            {
                graphics.DrawEllipse(Pens.DarkBlue, blackHole.X - blackHole.Radius / 2, blackHole.Y - blackHole.Radius / 2, blackHole.Radius, blackHole.Radius);
                graphics.DrawEllipse(Pens.BlueViolet, blackHole.X - blackHole.Radius * 2, blackHole.Y - blackHole.Radius * 2, blackHole.Radius * 4, blackHole.Radius * 4);
            }
            graphics.Dispose();
            brush.Dispose();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 786)
            {
                Int32 cs = m.WParam.ToInt32();
                if (cs == SightUp || cs == SightUpShift) sight.Y -= cs == SightUp ? 1 : 10;
                if (cs == SightDown || cs == SightDownShift) sight.Y += cs == SightDown ? 1 : 10;
                if (cs == SightLeft || cs == SightLeftShift) sight.X -= cs == SightLeft ? 1 : 10;
                if (cs == SightRight || cs == SightRightShift) sight.X += cs == SightRight ? 1 : 10;
                if (cs == AimQuit || cs == AimQuitShift) Close();
                if (cs == AngleLeft || cs == AngleLeftShift || cs == AngleRight || cs == AngleRightShift)
                {
                    if (cs == AngleLeft || cs == AngleLeftShift) angle -= cs == AngleLeft ? 1 : 10;
                    if (cs == AngleRight || cs == AngleRightShift) angle += cs == AngleRight ? 1 : 10;
                    angle = angle < 0 ? 360 + angle % 360 : angle % 360;
                    labelAngle.Text = (angle <= 90 ? angle : angle <= 270 ? 180 - angle : angle - 360) + @"°";
                }

                if (cs == PowerUp || cs == PowerUpShift || cs == PowerDown || cs == PowerDownShift)
                {
                    if (cs == PowerUp || cs == PowerUpShift) power += cs == PowerUp ? 1 : 10;
                    if (cs == PowerDown || cs == PowerDownShift) power -= cs == PowerDown ? 1 : 10;
                    power = power.LimitToRange(0, 100, false);
                    labelPower.Text = power + @"%";
                }

                if (cs == SetSightPosition || cs == SetSightPositionShift)
                {
                    sight.X = Cursor.Position.X;
                    sight.Y = Cursor.Position.Y;
                }

                if (cs == AimReset || cs == AimResetShift)
                {
                    Main_Form_Init();
                }

                try
                {
                    if (cs == SetWind || cs == SetWindShift)
                    {
                        wind = (Int32) Convert.ToInt16(Interaction.InputBox(localization.WindValue, localization.Wind,
                            Convert.ToString(wind), (Width / 2) - 170, (Height / 2) - 50));
                        labelWind.Text = wind + @"";
                    }

                    if (cs == SetAngle || cs == SetAngleShift)
                    {
                        angle = (Int32)Convert.ToInt16(Interaction.InputBox(localization.AngleValue, localization.Angle,
                            Convert.ToString(angle), (Width / 2) - 170, (Height / 2) - 50)) % 360;
                        labelAngle.Text = angle + @"°";
                    }

                    if (cs == SetPower || cs == SetPowerShift)
                    {
                        power = ((Int32) Convert.ToInt16(Interaction.InputBox(localization.PowerValue, localization.Power,
                            Convert.ToString(power), (Width / 2) - 170, (Height / 2) - 50))).LimitToRange(0, 100, false);
                        labelPower.Text = power + @"%";
                    }

                    if (cs == SetRadius || cs == SetRadiusShift)
                    {
                        sight.Radius = (Int32) Convert.ToInt16(Interaction.InputBox(localization.SightRadius, localization.Sight,
                            Convert.ToString(sight.Radius), (Width / 2) - 170, (Height / 2) - 50));
                    }

                    if (cs == SetPortalRadius)
                    {
                        portal.Radius = (Int32)Convert.ToInt16(Interaction.InputBox(localization.PortalRadius, localization.Portal,
                            Convert.ToString(portal.Radius), (Width / 2) - 170, (Height / 2) - 50));
                    }
                    if (cs == SetBlackHoleRadius)
                    {
                        blackHole.Radius = (Int32)Convert.ToInt16(Interaction.InputBox(localization.BlackHoleRadius, localization.BlackHole,
                            Convert.ToString(blackHole.Radius), (Width / 2) - 170, (Height / 2) - 50));
                    }

                }
                catch (Exception)
                {
                    // ignored
                }

                if (cs == ChangeGuidanceMode || cs == ChangeGuidanceModeShift)
                {
                    guidanceMode += (guidanceMode < MaxGuidanceMode) ? 1 : -guidanceMode;
                }
                if (cs == SetFirstPortal)
                {
                    portal.FirstPortal.X = Cursor.Position.X;
                    portal.FirstPortal.Y = Cursor.Position.Y;
                }

                if (cs == SetSecondPortal)
                {
                    portal.SecondPortal.X = Cursor.Position.X;
                    portal.SecondPortal.Y = Cursor.Position.Y;
                }

                if (cs == ResetPortals)
                {
                    portal.FirstPortal.X = portal.FirstPortal.Y = portal.SecondPortal.X = portal.SecondPortal.Y = 0;
                }

                if (cs == SetBlackHole || cs == SetBlackHoleShift)
                {
                    blackHole.X = Cursor.Position.X;
                    blackHole.Y = Cursor.Position.Y;
                }

                if (cs == ResetBlackHole)
                {
                    blackHole.X = blackHole.Y = 0;
                }
                Invalidate();
                Update();
            }

            base.WndProc(ref m);
        }

        protected override void Dispose(Boolean disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        private void InitializeComponent()
        {
            labelPower = new Label();
            labelAngle = new Label();
            labelWind = new Label();
            Button imageButtonSight = new Button();
            SuspendLayout();

            labelPower.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelPower.BackColor = Color.FromArgb(75, 0, 0);
            labelPower.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, (Byte) 204);
            labelPower.ForeColor = Color.FromArgb(255, 255, 255);
            labelPower.Location = new Point(350, 360);
            labelPower.Margin = new Padding(0);
            labelPower.Size = new Size(150, 30);
            labelPower.TabIndex = 0;
            labelPower.TextAlign = ContentAlignment.MiddleCenter;

            labelAngle.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelAngle.BackColor = Color.FromArgb(0, 75, 0);
            labelAngle.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, (Byte) 204);
            labelAngle.ForeColor = Color.FromArgb(255, 255, 255);
            labelAngle.Location = new Point(350, 320);
            labelAngle.Margin = new Padding(0);
            labelAngle.Size = new Size(70, 30);
            labelAngle.TabIndex = 1;
            labelAngle.TextAlign = ContentAlignment.MiddleCenter;

            labelWind.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelWind.BackColor = Color.FromArgb(0, 75, 75);
            labelWind.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, (Byte)204);
            labelWind.ForeColor = Color.FromArgb(255, 255, 255);
            labelWind.Location = new Point(430, 320);
            labelWind.Margin = new Padding(0);
            labelWind.Size = new Size(70, 30);
            labelWind.TabIndex = 4;
            labelWind.TextAlign = ContentAlignment.MiddleCenter;
            labelWind.Visible = true;

            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(784, 412);
            Controls.Add(labelAngle);
            Controls.Add(labelPower);
            Controls.Add(labelWind);
            FormBorderStyle = FormBorderStyle.None;
            Name = nameof(Ruler);
            Text = $@"Aim Version {ProgramVersion.ToString(CultureInfo.InvariantCulture)}";
            TopMost = true;
            Icon = Resources.icon;
            TransparencyKey = Color.Black;
            WindowState = FormWindowState.Maximized;
            Shown += new EventHandler(Main_Form_Init);
            Paint += new PaintEventHandler(Main_Form_Paint);
            
            ResumeLayout(false);
        }
    }
}