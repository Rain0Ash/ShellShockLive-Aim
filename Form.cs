// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
// TODO: Do portals, black holes and rebound walls. Do GUI for control this objects by mouse. Do auto set value of wind, auto setup objects and user tank position.
// TODO: Дописать порталы. Добавить предустановленные режимы экрана. Дописать стены и черные дыры. Сделать графический интерфейс. Сделать автоопределение ветра, автонаводку, автоопределение позиции танка, автоустановку объектов.
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace ssl_aimbot
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
    public class MainForm : Form
    {
        private readonly IContainer components = null;
        private Int32 h, w, x, y, ph, len, angle, power, wind, mode, firstPortalX, firstPortalY, secondPortalX, secondPortalY, portalRadius, blackHoleX, blackHoleY, blackHoleRadius;
        private Single pointX, pointY;
        private Double g, v, r, ww;
        private const Int32 MaxMode = 1;
        private const Int32 Alt = 1, Ctrl = 2, CtrlAlt = 3, Shift = 4, AltShift = 5, CtrlShift = 6, CtrlAltShift = 7;
        private const Int32 KeyArrowRight = 37, KeyArrowUp = 38, KeyArrowLeft = 39, KeyArrowDown = 40, KeyA = 65, KeyB = 66, KeyC = 67, KeyD = 68, KeyE = 69, KeyF = 70, KeyG = 71, KeyH = 72, KeyI = 73, KeyJ = 74, KeyK = 75, KeyL = 76, KeyM = 77, KeyN = 78, KeyO = 79, KeyP = 80, KeyQ = 81, KeyR = 82, KeyS = 83, KeyT = 84, KeyU = 85, KeyV = 86, KeyW = 87, KeyX = 88, KeyY = 89, KeyZ = 90;
        private const Int32 SightUp = 1, SightDown = 2, SightLeft = 3, SightRight = 4, AimQuit = 5, AngleLeft = 6, AngleRight = 7, PowerUp = 8, PowerDown = 9, SetSightPosition = 10, AimReset = 11, SetWind = 12, SetAngle = 13, SetPower = 14, SetRadius = 15, ChangeGuidanceMode = 16, SightUpShift = 31, SightDownShift = 32, SightLeftShift = 33, SightRightShift = 34, AimQuitShift = 35, AngleLeftShift = 36, AngleRightShift = 37, PowerUpShift = 38, PowerDownShift = 39, SetSightPositionShift = 40, AimResetShift = 41, SetWindShift = 42, SetAngleShift = 43, SetPowerShift = 44, SetRadiusShift = 45, ChangeGuidanceModeShift = 46, SetPortalRadius = 60, SetFirstPortal = 61, SetSecondPortal = 62, ResetPortals = 63, SetBlackHoleRadius = 64, SetBlackHole = 65, SetBlackHoleShift = 66, ResetBlackHole = 67;
        private const Double ProgramVersion = 0.77;
        private Label labelPower, labelAngle, labelWind;
        [DllImport("user32.dll")]
        private static extern Boolean RegisterHotKey(IntPtr hWnd, Int32 id, Int32 fsModifiers, Int32 vlc);
        // [DllImport("user32.dll")]
        // private static extern Boolean UnregisterHotKey(IntPtr hWnd, Int32 id);

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
        public MainForm()
        {
            RegisterHotKey(Handle, SightUp, Ctrl, KeyW);
            RegisterHotKey(Handle, SightLeft, Ctrl, KeyA);
            RegisterHotKey(Handle, SightDown, Ctrl, KeyS);
            RegisterHotKey(Handle, SightRight, Ctrl, KeyD);
            RegisterHotKey(Handle, AimQuit, Ctrl, KeyQ);
            RegisterHotKey(Handle, AngleLeft, Ctrl, KeyArrowLeft);
            RegisterHotKey(Handle, AngleRight, Ctrl, KeyArrowRight);
            RegisterHotKey(Handle, PowerUp, Ctrl, KeyArrowUp);
            RegisterHotKey(Handle, PowerDown, Ctrl, KeyArrowDown);
            RegisterHotKey(Handle, SightUpShift, CtrlShift, KeyW);
            RegisterHotKey(Handle, SightLeftShift, CtrlShift, KeyA);
            RegisterHotKey(Handle, SightDownShift, CtrlShift, KeyS);
            RegisterHotKey(Handle, SightRightShift, CtrlShift, KeyD);
            RegisterHotKey(Handle, AimQuitShift, CtrlShift, KeyQ);
            RegisterHotKey(Handle, AngleLeftShift, CtrlShift, KeyArrowLeft);
            RegisterHotKey(Handle, AngleRightShift, CtrlShift, KeyArrowRight);
            RegisterHotKey(Handle, PowerUpShift, CtrlShift, KeyArrowUp);
            RegisterHotKey(Handle, PowerDownShift, CtrlShift, KeyArrowDown);
            RegisterHotKey(Handle, SetSightPosition, Ctrl, KeyE);
            RegisterHotKey(Handle, AimReset, Ctrl, KeyZ);
            RegisterHotKey(Handle, SetWind, Ctrl, KeyF);
            RegisterHotKey(Handle, SetAngle, Ctrl, KeyG);
            RegisterHotKey(Handle, SetPower, Ctrl, KeyH);
            RegisterHotKey(Handle, SetRadius, Ctrl, KeyR);
            RegisterHotKey(Handle, ChangeGuidanceMode, Ctrl, KeyM);
            RegisterHotKey(Handle, SetSightPositionShift, CtrlShift, KeyE);
            RegisterHotKey(Handle, AimResetShift, CtrlShift, KeyZ);
            RegisterHotKey(Handle, SetWindShift, CtrlShift, KeyF);
            RegisterHotKey(Handle, SetAngleShift, CtrlShift, KeyG);
            RegisterHotKey(Handle, SetPowerShift, CtrlShift, KeyH);
            RegisterHotKey(Handle, SetRadiusShift, CtrlShift, KeyR);
            RegisterHotKey(Handle, ChangeGuidanceModeShift, CtrlShift, KeyM);
            RegisterHotKey(Handle, SetPortalRadius, CtrlAlt, KeyP);
            RegisterHotKey(Handle, SetFirstPortal, Ctrl, KeyP);
            RegisterHotKey(Handle, SetSecondPortal, CtrlShift, KeyP);
            RegisterHotKey(Handle, ResetPortals, CtrlAltShift, KeyP);
            RegisterHotKey(Handle, SetBlackHoleRadius, CtrlAlt, KeyB);
            RegisterHotKey(Handle, SetBlackHole, Ctrl, KeyB);
            RegisterHotKey(Handle, SetBlackHoleShift, CtrlShift, KeyB);
            RegisterHotKey(Handle, ResetBlackHole, CtrlAltShift, KeyB);
            InitializeComponent();
        }

        private void Main_Form_Shown(Object sender = null, EventArgs e = null)
        {
            h = Height;
            w = Width;
            x = w / 2;
            y = h / 2;
            mode = 0;
            angle = 85;
            power = 100;
            g = 9.8;
            v = 1.317;
            r = 20.0;
            wind = 0;
            ww = 1.0 / 80.0;
            ph = 145;
            len = 236;
            firstPortalX = secondPortalX = firstPortalY = secondPortalY = blackHoleX = blackHoleY = 0;
            portalRadius = blackHoleRadius = 50;
            labelPower.Text = power + @"%";
            labelAngle.Text = angle + @"°";
            labelWind.Text = wind + @"";
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
                Single sin = len * (Single) Math.Sin(Math.PI * circleAngle / 180f) * 1.05f;
                Single cos = len * (Single) Math.Cos(Math.PI * circleAngle / 180f) * 1.05f;
                graphics.DrawLine(pen, x, y, x + cos, y - sin);
            }
            for (Int32 circleRange = 25; circleRange <= 100; circleRange += 25)
            {
                if (circleRange % 100 == 0) pen = Pens.LightCoral;
                else if (circleRange % 75 == 0) pen = Pens.LightGoldenrodYellow;
                else if (circleRange % 50 == 0) pen = Pens.LightGreen;
                else if (circleRange % 25 == 0) pen = Pens.LightSeaGreen;
                else if (circleRange % 10 == 0) pen = Pens.DarkBlue;
                else pen = Pens.DarkGray;
                graphics.DrawEllipse(pen, x - (len * circleRange / 100f), y - (len * circleRange / 100f), len * (2f * circleRange / 100f), len * (2f * circleRange / 100f));
            }
            graphics.DrawLine(Pens.Red, x, y, x + len * (Single)Math.Cos(Math.PI * angle / 180f) * power / 100f, y - len * (Single)Math.Sin(Math.PI * angle / 180f) * power / 100f);
            SolidBrush brush = new SolidBrush(Color.FromArgb(15, 220, 15));
            graphics.FillEllipse((Brush) brush, x - 4, y - 4, 8, 8);
            // graphics.DrawString("Made by Rain0Ash", font, Brushes.Azure, 0, 0);
            Double floatAngle = (Double) angle * (Math.PI / 180.0);
            Single floatAngleSin = (Single)Convert.ToInt16(r * Math.Sin(floatAngle));
            Single floatAngleCos = (Single) Convert.ToInt16(r * Math.Cos(floatAngle));
            brush.Color = Color.White;
            Single counter = 0.0f;
            Boolean portalCheck = true;
            Single _x = x;
            Single _y = y;
            Int32 portalCounter = 0;
            while ((Double) counter < 50.0)
            {
                switch (mode)
                {
                    case 0:
                    {
                        pointX = Convert.ToSingle((Double) _x + 
                                                  ((Double) power * v * (Double) counter * Math.Cos(floatAngle)) +
                                                  (0.5 * (Double) wind * ww * (Double) counter * (Double) counter));
                        pointY = Convert.ToSingle((Double) _y -
                                                  ((Double) power * v * (Double) counter * Math.Sin(floatAngle)) +
                                                  (0.5 * g * (Double) counter * (Double) counter));
                        if ((Double)pointY <= (Double)(h - ph))
                        {
                            graphics.FillEllipse((Brush)brush, (Single)((Double)pointX + (Double)floatAngleCos - 1.0), (Single)((Double)pointY - (Double)floatAngleSin - 1.0), 2f, 2f);
                        }
                        counter += 0.05f;
                        break;
                    }
                    case 1:
                    {
                        pointX = _x + len * (Single)Math.Cos(Math.PI * angle / 180f) * counter;
                        pointY = _y - len * (Single)Math.Sin(Math.PI * angle / 180f) * counter;
                        graphics.FillEllipse((Brush)brush, pointX, pointY, 2f, 2f);
                        counter += 0.03f;
                        break;
                    }
                }

                if (portalRadius > 0 && firstPortalX > 0 && firstPortalY > 0 && secondPortalX > 0 && secondPortalY > 0)
                {
                    Boolean firstPortalIntersection = (Math.Sqrt(Math.Pow(firstPortalX - pointX, 2) + Math.Pow(firstPortalY - pointY, 2)) < (Double) portalRadius / 2);
                    Boolean secondPortalIntersection = (Math.Sqrt(Math.Pow(secondPortalX - pointX, 2) + Math.Pow(secondPortalY - pointY, 2)) < (Double) portalRadius / 2);
                    if (portalCheck && (firstPortalIntersection ^ secondPortalIntersection) && portalCounter < 3)
                    {
                        _x = (firstPortalIntersection ? secondPortalX : firstPortalX) - ((firstPortalIntersection ? firstPortalX : secondPortalX) - pointX);
                        _y = (firstPortalIntersection ? secondPortalY : firstPortalY) - ((firstPortalIntersection ? firstPortalY : secondPortalY) - pointY);
                        portalCounter += 1;
                        portalCheck = false;
                    }

                    if (!portalCheck && !(firstPortalIntersection || secondPortalIntersection))
                    {
                        portalCheck = true;
                    }
                }

                if (blackHoleRadius > 0 && blackHoleX > 0 && blackHoleY > 0)
                {
                    Boolean blackHoleEventHorizonIntersection = (Math.Sqrt(Math.Pow(blackHoleX - pointX, 2) + Math.Pow(blackHoleY - pointY, 2)) < (Double) blackHoleRadius / 2);
                    Boolean blackHoleGravityRadiusIntersection = (Math.Sqrt(Math.Pow(blackHoleX - pointX, 2) + Math.Pow(blackHoleY - pointY, 2)) < (Double) portalRadius *2);
                    if (blackHoleEventHorizonIntersection)
                    {
                        break;
                    }
                    else if (blackHoleGravityRadiusIntersection)
                    {
                        g = -Math.Abs(g);
                    }
                    else
                    {
                        g = Math.Abs(g);
                    }
                }

            }
            if (portalRadius > 0)
            {
                if (firstPortalX > 0 && firstPortalY > 0)
                {
                    graphics.DrawEllipse(Pens.CornflowerBlue, firstPortalX-portalRadius / 2, firstPortalY-portalRadius / 2, portalRadius, portalRadius);
                }
                if (secondPortalX > 0 && secondPortalY > 0)
                {
                    graphics.DrawEllipse(Pens.Orange, secondPortalX-portalRadius / 2, secondPortalY-portalRadius / 2, portalRadius, portalRadius);
                }

            }

            if (blackHoleRadius > 0 && blackHoleX > 0 && blackHoleY > 0)
            {
                graphics.DrawEllipse(Pens.DarkBlue, blackHoleX - blackHoleRadius / 2, blackHoleY - blackHoleRadius / 2, blackHoleRadius, blackHoleRadius);
                graphics.DrawEllipse(Pens.BlueViolet, blackHoleX - blackHoleRadius * 2, blackHoleY - blackHoleRadius * 2, blackHoleRadius * 4, blackHoleRadius * 4);
            }
            graphics.Dispose();
            brush.Dispose();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 786)
            {
                Int32 cs = m.WParam.ToInt32();
                if (cs == SightUp || cs == SightUpShift) y -= cs == SightUp ? 1 : 10;
                if (cs == SightDown || cs == SightDownShift) y += cs == SightDown ? 1 : 10;
                if (cs == SightLeft || cs == SightLeftShift) x -= cs == SightLeft ? 1 : 10;
                if (cs == SightRight || cs == SightRightShift) x += cs == SightRight ? 1 : 10;
                if (cs == AimQuit || cs == AimQuitShift) Close();
                if (cs == AngleLeft || cs == AngleLeftShift || cs == AngleRight || cs == AngleRightShift)
                {
                    if (cs == AngleLeft || cs == AngleLeftShift) angle -= cs == AngleLeft ? 1 : 10;
                    if (cs == AngleRight || cs == AngleRightShift) angle += cs == AngleRight ? 1 : 10;
                    angle = angle < 0 ? 360 + angle % 360 : angle % 360;
                    labelAngle.Text = (angle <= 90 ? angle : angle <= 270 ? 180 - angle : angle - 360).ToString() + "°";
                }

                if (cs == PowerUp || cs == PowerUpShift || cs == PowerDown || cs == PowerDownShift)
                {
                    if (cs == PowerUp || cs == PowerUpShift) power += cs == PowerUp ? 1 : 10;
                    if (cs == PowerDown || cs == PowerDownShift) power -= cs == PowerDown ? 1 : 10;
                    power = power.LimitToRange(0, 100, false);
                    labelPower.Text = power.ToString() + @"%";
                }

                if (cs == SetSightPosition || cs == SetSightPositionShift)
                {
                    x = Cursor.Position.X;
                    y = Cursor.Position.Y;
                }

                if (cs == AimReset || cs == AimResetShift)
                {
                    Main_Form_Shown();
                }

                try
                {
                    if (cs == SetWind || cs == SetWindShift)
                    {
                        wind = (Int32) Convert.ToInt16(Interaction.InputBox("Параметр ветра", "Ветер",
                            Convert.ToString(wind), (w / 2) - 170, (h / 2) - 50));
                        labelWind.Text = wind.ToString();
                    }

                    if (cs == SetAngle || cs == SetAngleShift)
                    {
                        angle = (Int32)Convert.ToInt16(Interaction.InputBox("Параметр угла", "Угол",
                            Convert.ToString(angle), (w / 2) - 170, (h / 2) - 50)) % 360;
                        labelAngle.Text = angle.ToString();
                    }

                    if (cs == SetPower || cs == SetPowerShift)
                    {
                        power = ((Int32) Convert.ToInt16(Interaction.InputBox("Параметр силы", "Сила",
                            Convert.ToString(power), (w / 2) - 170, (h / 2) - 50))).LimitToRange(0, 100, false);
                        labelPower.Text = power.ToString() + "%";
                    }

                    if (cs == SetRadius || cs == SetRadiusShift)
                    {
                        len = (Int32) Convert.ToInt16(Interaction.InputBox("Радиус круга", "Радиус",
                            Convert.ToString(len), (w / 2) - 170, (h / 2) - 50));
                    }

                    if (cs == SetPortalRadius)
                    {
                        portalRadius = (Int32)Convert.ToInt16(Interaction.InputBox("Параметр размера портала", "Портал",
                            Convert.ToString(portalRadius), (w / 2) - 170, (h / 2) - 50));
                    }
                    if (cs == SetBlackHoleRadius)
                    {
                        blackHoleRadius = (Int32)Convert.ToInt16(Interaction.InputBox("Параметр размера черной дыры", "Черная дыра",
                            Convert.ToString(blackHoleRadius), (w / 2) - 170, (h / 2) - 50));
                    }

                }
                catch (Exception)
                {
                    // ignored
                }

                if (cs == ChangeGuidanceMode || cs == ChangeGuidanceModeShift)
                {
                    mode += (mode < MaxMode) ? 1 : -mode;
                }
                if (cs == SetFirstPortal)
                {
                    firstPortalX = Cursor.Position.X;
                    firstPortalY = Cursor.Position.Y;
                }

                if (cs == SetSecondPortal)
                {
                    secondPortalX = Cursor.Position.X;
                    secondPortalY = Cursor.Position.Y;
                }

                if (cs == ResetPortals)
                {
                    firstPortalX = firstPortalY = secondPortalX = secondPortalY = 0;
                }

                if (cs == SetBlackHole || cs == SetBlackHoleShift)
                {
                    blackHoleX = Cursor.Position.X;
                    blackHoleY = Cursor.Position.Y;
                }

                if (cs == ResetBlackHole)
                {
                    blackHoleX = blackHoleY = 0;
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
            SuspendLayout();

            labelPower.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelPower.BackColor = Color.FromArgb(75, 0, 0);
            labelPower.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, (Byte) 204);
            labelPower.ForeColor = Color.FromArgb(255, 255, 255);
            labelPower.Location = new Point(350, 360);
            labelPower.Margin = new Padding(0);
            labelPower.Name = "labelPower";
            labelPower.Size = new Size(150, 30);
            labelPower.TabIndex = 0;
            labelPower.TextAlign = ContentAlignment.MiddleCenter;

            labelAngle.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelAngle.BackColor = Color.FromArgb(0, 75, 0);
            labelAngle.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, (Byte) 204);
            labelAngle.ForeColor = Color.FromArgb(255, 255, 255);
            labelAngle.Location = new Point(350, 320);
            labelAngle.Margin = new Padding(0);
            labelAngle.Name = "labelAngle";
            labelAngle.Size = new Size(70, 30);
            labelAngle.TabIndex = 1;
            labelAngle.TextAlign = ContentAlignment.MiddleCenter;

            labelWind.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelWind.BackColor = Color.FromArgb(0, 75, 75);
            labelWind.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, (Byte)204);
            labelWind.ForeColor = Color.FromArgb(255, 255, 255);
            labelWind.Location = new Point(430, 320);
            labelWind.Margin = new Padding(0);
            labelWind.Name = "labelWind";
            labelWind.Size = new Size(70, 30);
            labelWind.TabIndex = 4;
            labelWind.TextAlign = ContentAlignment.MiddleCenter;
            labelWind.Visible = true;

            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(784, 412);
            Controls.Add((Control) labelAngle);
            Controls.Add((Control) labelPower);
            Controls.Add((Control) labelWind);
            FormBorderStyle = FormBorderStyle.None;
            Name = nameof(MainForm);
            Text = $@"Aim Version {ProgramVersion.ToString(CultureInfo.InvariantCulture)}";
            TopMost = true;
            Icon = Properties.Resources.icon;
            TransparencyKey = Color.Black;
            WindowState = FormWindowState.Maximized;
            Shown += new EventHandler(Main_Form_Shown);
            Paint += new PaintEventHandler(Main_Form_Paint);
            ResumeLayout(false);
        }
    }
}