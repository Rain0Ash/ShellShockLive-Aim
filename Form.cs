// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
// TODO: Сменить имена переменных на более осмысленные. Дописать порталы. Дописать стены и черные дыры. Зарефакторить код/переписать на python.
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace ssl_aimbot
{
    public static class Functions
    {
        public static Int32 LimitToRange(
            this Int32 value, Int32 inclusive_minimum, Int32 inclusive_maximum, Boolean reverse = false)
        {
            if (value < inclusive_minimum) { return reverse ? inclusive_maximum : inclusive_minimum; }
            if (value > inclusive_maximum) { return reverse ? inclusive_minimum : inclusive_maximum; }
            return value;
        }
    }
    public class Main_Form : Form
    {
        private IContainer components = null;
        private Int32 h, w, x, y, ph, len, angle, power, wind, mode, cs, first_portal_x, first_portal_y, second_portal_x, second_portal_y, portal_radius;
        private Double g, v, r, ww;
        private const Int32 maxmode = 1;
        private const Int32 alt = 1, ctrl = 2, ctrl_alt = 3, shift = 4, alt_shift = 5, ctrl_shift = 6, ctrl_alt_shift = 7;
        private const Int32 key_arrow_right = 37, key_arrow_up = 38, key_arrow_left = 39, key_arrow_down = 40, key_a = 65, key_b = 66, key_c = 67, key_d = 68, key_e = 69, key_f = 70, key_g = 71, key_h = 72, key_i = 73, key_j = 74, key_k = 75, key_l = 76, key_m = 77, key_n = 78, key_o = 79, key_p = 80, key_q = 81, key_r = 82, key_s = 83, key_t = 84, key_u = 85, key_v = 86, key_w = 87, key_x = 88, key_y = 89, key_z = 90;
        private const Int32 sight_up = 1, sight_down = 2, sight_left = 3, sight_right = 4, aim_quit = 5, angle_left = 6, angle_right = 7, power_up = 8, power_down = 9, set_sight_position = 10, aim_reset = 11, set_wind = 12, set_angle = 13, set_power = 14, set_radius = 15, change_guidance_mode = 16, sight_up_shift = 31, sight_down_shift = 32, sight_left_shift = 33, sight_right_shift = 34, aim_quit_shift = 35, angle_left_shift = 36, angle_right_shift = 37, power_up_shift = 38, power_down_shift = 39, set_sight_position_shift = 40, aim_reset_shift = 41, set_wind_shift = 42, set_angle_shift = 43, set_power_shift = 44, set_radius_shift = 45, change_guidance_mode_shift = 46, set_portal_radius = 60, set_first_portal = 61, set_second_portal = 62, reset_portals = 63;
        private const Double version = 0.73;
        private Label lpower, langle, lwind;
        [DllImport("user32.dll")]
        private static extern Boolean RegisterHotKey(IntPtr hWnd, Int32 id, Int32 fsModifiers, Int32 vlc);
        [DllImport("user32.dll")]
        private static extern Boolean UnregisterHotKey(IntPtr hWnd, Int32 id);
        [DllImport("user32.dll")]
        private static extern Int16 VkKeyScan(Char ch);

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
        public Main_Form()
        {
            RegisterHotKey(Handle, sight_up, ctrl, key_w);
            RegisterHotKey(Handle, sight_left, ctrl, key_a);
            RegisterHotKey(Handle, sight_down, ctrl, key_s);
            RegisterHotKey(Handle, sight_right, ctrl, key_d);
            RegisterHotKey(Handle, aim_quit, ctrl, key_q);
            RegisterHotKey(Handle, angle_left, ctrl, key_arrow_left);
            RegisterHotKey(Handle, angle_right, ctrl, key_arrow_right);
            RegisterHotKey(Handle, power_up, ctrl, key_arrow_up);
            RegisterHotKey(Handle, power_down, ctrl, key_arrow_down);
            RegisterHotKey(Handle, sight_up_shift, ctrl_shift, key_w);
            RegisterHotKey(Handle, sight_left_shift, ctrl_shift, key_a);
            RegisterHotKey(Handle, sight_down_shift, ctrl_shift, key_s);
            RegisterHotKey(Handle, sight_right_shift, ctrl_shift, key_d);
            RegisterHotKey(Handle, aim_quit_shift, ctrl_shift, key_q);
            RegisterHotKey(Handle, angle_left_shift, ctrl_shift, key_arrow_left);
            RegisterHotKey(Handle, angle_right_shift, ctrl_shift, key_arrow_right);
            RegisterHotKey(Handle, power_up_shift, ctrl_shift, key_arrow_up);
            RegisterHotKey(Handle, power_down_shift, ctrl_shift, key_arrow_down);
            RegisterHotKey(Handle, set_sight_position, ctrl, key_e);
            RegisterHotKey(Handle, aim_reset, ctrl, key_z);
            RegisterHotKey(Handle, set_wind, ctrl, key_f);
            RegisterHotKey(Handle, set_angle, ctrl, key_g);
            RegisterHotKey(Handle, set_power, ctrl, key_h);
            RegisterHotKey(Handle, set_radius, ctrl, key_r);
            RegisterHotKey(Handle, change_guidance_mode, ctrl, key_m);
            RegisterHotKey(Handle, set_sight_position_shift, ctrl_shift, key_e);
            RegisterHotKey(Handle, aim_reset_shift, ctrl_shift, key_z);
            RegisterHotKey(Handle, set_wind_shift, ctrl_shift, key_f);
            RegisterHotKey(Handle, set_angle_shift, ctrl_shift, key_g);
            RegisterHotKey(Handle, set_power_shift, ctrl_shift, key_h);
            RegisterHotKey(Handle, set_radius_shift, ctrl_shift, key_r);
            RegisterHotKey(Handle, change_guidance_mode_shift, ctrl_shift, key_m);
            RegisterHotKey(Handle, set_portal_radius, ctrl_alt, key_p);
            RegisterHotKey(Handle, set_first_portal, ctrl, key_p);
            RegisterHotKey(Handle, set_second_portal, ctrl_shift, key_p);
            RegisterHotKey(Handle, reset_portals, ctrl_alt_shift, key_p);
            InitializeComponent();
        }

        private void Main_Form_Shown(Object sender, EventArgs e)
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
            first_portal_x = second_portal_x = first_portal_y = second_portal_y = 0;
            portal_radius = 50;
            lpower.Text = power.ToString() + "%";
            langle.Text = angle.ToString() + "°";
            lwind.Text = wind.ToString();
        }

        private void Main_Form_Paint(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Pen pen = new Pen(Color.FromArgb(47, 68, 86), 1f);
            Font font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            for (Int32 cangle = 0; cangle < 360; cangle += 45)
            {
                if (cangle % 90 == 0) pen = Pens.Red;
                else if (cangle % 60 == 0) pen = Pens.Yellow;
                else if (cangle % 45 == 0) pen = cangle < 180 ? Pens.Aquamarine : Pens.Blue;
                else if (cangle % 30 == 0) pen = Pens.GreenYellow;
                else if (cangle % 15 == 0) pen = cangle < 180 ? Pens.Orange : Pens.Brown;
                else pen = Pens.DarkGray;
                Single sin = len * (Single) Math.Sin(Math.PI * cangle / 180f) * 1.05f;
                Single cos = len * (Single) Math.Cos(Math.PI * cangle / 180f) * 1.05f;
                graphics.DrawLine(pen, x, y, x + cos, y - sin);
            }
            for (Int32 range = 25; range <= 100; range += 25)
            {
                if (range % 100 == 0) pen = Pens.LightCoral;
                else if (range % 75 == 0) pen = Pens.LightGoldenrodYellow;
                else if (range % 50 == 0) pen = Pens.LightGreen;
                else if (range % 25 == 0) pen = Pens.LightSeaGreen;
                else if (range % 10 == 0) pen = Pens.DarkBlue;
                else pen = Pens.DarkGray;
                graphics.DrawEllipse(pen, x - (len * range / 100f), y - (len * range / 100f), len * (2f * range / 100f), len * (2f * range / 100f));
            }
            graphics.DrawLine(Pens.Red, x, y, x + len * (Single)Math.Cos(Math.PI * angle / 180f) * power / 100f, y - len * (Single)Math.Sin(Math.PI * angle / 180f) * power / 100f);
            SolidBrush brush = new SolidBrush(Color.FromArgb(15, 219, 18));
            graphics.FillEllipse((Brush) brush, x - 4, y - 4, 8, 8);
            graphics.DrawString("Made by Rain0Ash", font, Brushes.Azure, 0, 0);
            Double float_angle = (Double) angle * (Math.PI / 180.0);
            Single float_angle_sin = (Single)Convert.ToInt16(r * Math.Sin(float_angle));
            Single float_angle_cos = (Single) Convert.ToInt16(r * Math.Cos(float_angle));
            brush.Color = Color.White;
            Single counter = 0.0f;
            Boolean portal_check = true;
            Single _x = x;
            Single _y = y;
            while ((Double) counter < 50.0)
            {
                if (mode == 0)
                {
                    /*
                     [YES]Если установлены два телепорта
                     {
                         [YES]Получаем координаты точки.
                         [YES]Если координаты точки в телепорте и нет флага
                         {
                            [NO]Изменяем координаты к второму телепорту и устанавливаем флаг
                         } 
                         [YES]Если стоит флаг и точка вне телепорта
                         {
                            [YES]Убираем флаг
                         }
                     }
                    */
                    Single point_x = Convert.ToSingle((Double) _x + 
                    ((Double) power * v * (Double) counter * Math.Cos(float_angle)) +
                                                   (0.5 * (Double) wind * ww * (Double) counter * (Double) counter));
                    Single point_y = Convert.ToSingle((Double) _y -
                                                   ((Double) power * v * (Double) counter * Math.Sin(float_angle)) +
                                                   (0.5 * g * (Double) counter * (Double) counter));

                    if (portal_radius > 0 && first_portal_x > 0 && first_portal_y > 0 && second_portal_x > 0 && second_portal_y > 0)
                    {
                        Boolean first_portal_intersection = (Math.Sqrt(Math.Pow(Math.Abs(first_portal_x - point_x), 2) + Math.Pow(Math.Abs(first_portal_y - point_y), 2)) <  portal_radius / 2);
                        Boolean second_portal_intersection = (Math.Sqrt(Math.Pow(Math.Abs(second_portal_x - point_x), 2) + Math.Pow(Math.Abs(second_portal_y - point_y), 2)) < portal_radius / 2);
                        Int32 portal_counter = 0;
                        
                        if (portal_check && first_portal_intersection && portal_counter < 30)
                        {
                            _x = second_portal_x;
                            _y = second_portal_y;
                            portal_counter++;
                            portal_check = false;
                        }
                        else if (portal_check && second_portal_intersection && portal_counter < 30)
                        {
                            _x = first_portal_x;
                            _y = first_portal_y;
                            portal_counter++;
                            portal_check = false;
                        }

                        if (!portal_check && !(first_portal_intersection || second_portal_intersection))
                        {
                            portal_check = true;
                        }
                    }
                    if ((Double)point_y <= (Double)(h - ph))
                    {
                        graphics.FillEllipse((Brush)brush, (Single)((Double)point_x + (Double)float_angle_cos - 1.0), (Single)((Double)point_y - (Double)float_angle_sin - 1.0), 2f, 2f);
                    }
                    counter += 0.05f;
                }

                if (mode == 1)
                {
                    Single point_x = _x + len * (Single)Math.Cos(Math.PI * angle / 180f) * counter;
                    Single point_y = _y - len * (Single)Math.Sin(Math.PI * angle / 180f) * counter;
                    if (portal_radius > 0 && first_portal_x > 0 && first_portal_y > 0 && second_portal_x > 0 && second_portal_y > 0)
                    {
                        Boolean first_portal_intersection = (Math.Sqrt(Math.Pow(Math.Abs(first_portal_x - point_x), 2) + Math.Pow(Math.Abs(first_portal_y - point_y), 2)) < portal_radius / 2);
                        Boolean second_portal_intersection = (Math.Sqrt(Math.Pow(Math.Abs(second_portal_x - point_x), 2) + Math.Pow(Math.Abs(second_portal_y - point_y), 2)) < portal_radius / 2);
                        Int32 portal_counter = 0;
                        if (portal_check && first_portal_intersection && portal_counter < 30)
                        {
                            _x = second_portal_x;
                            _y = second_portal_y;
                            portal_counter++;
                            portal_check = false;
                        }
                        else if (portal_check && second_portal_intersection && portal_counter < 30)
                        {
                            _x = first_portal_x;
                            _y = first_portal_y;
                            portal_counter++;
                            portal_check = false;
                        }

                        if (!portal_check && !(first_portal_intersection || second_portal_intersection))
                        {
                            portal_check = true;
                        }
                    }
                    graphics.FillEllipse((Brush)brush, point_x, point_y, 2f, 2f);
                    counter += 0.03f;
                }


            }
            if (portal_radius > 0)
            {
                if (first_portal_x > 0 && first_portal_y > 0)
                {
                    pen = Pens.Blue;
                    graphics.DrawEllipse(pen, first_portal_x-portal_radius / 2, first_portal_y-portal_radius/2, portal_radius, portal_radius);
                }
                if (second_portal_x > 0 && second_portal_y > 0)
                {
                    pen = Pens.Orange;
                    graphics.DrawEllipse(pen, second_portal_x-portal_radius / 2, second_portal_y-portal_radius / 2, portal_radius, portal_radius);
                }

            }
            graphics.Dispose();
            brush.Dispose();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 786)
            {
                cs = m.WParam.ToInt32();
                if (cs == sight_up || cs == sight_up_shift) y -= cs == sight_up ? 1 : 10;
                if (cs == sight_down || cs == sight_down_shift) y += cs == sight_down ? 1 : 10;
                if (cs == sight_left || cs == sight_left_shift) x -= cs == sight_left ? 1 : 10;
                if (cs == sight_right || cs == sight_right_shift) x += cs == sight_right ? 1 : 10;
                if (cs == aim_quit || cs == aim_quit_shift) Close();
                if (cs == angle_left || cs == angle_left_shift || cs == angle_right || cs == angle_right_shift)
                {
                    if (cs == angle_left || cs == angle_left_shift) angle -= cs == angle_left ? 1 : 10;
                    if (cs == angle_right || cs == angle_right_shift) angle += cs == angle_right ? 1 : 10;
                    angle = angle < 0 ? 360 + angle % 360 : angle % 360;
                    //SendKeys.SendWait((cs == angle_left || cs == angle_left_shift) ? "{RIGHT}" : "{LEFT}");
                    langle.Text = (angle <= 90 ? angle : angle <= 270 ? 180 - angle : angle - 360).ToString() + "°";
                }

                if (cs == power_up || cs == power_up_shift || cs == power_down || cs == power_down_shift)
                {
                    if (cs == power_up || cs == power_up_shift) power += cs == power_up ? 1 : 10;
                    if (cs == power_down || cs == power_down_shift) power -= cs == power_down ? 1 : 10;
                    power = Functions.LimitToRange(power, 0, 100, false);
                    //SendKeys.SendWait((cs == power_up || cs == power_up_shift) ? "{UP}" : "{DOWN}");
                    lpower.Text = power.ToString() + "%";
                }

                if (cs == set_sight_position || cs == set_sight_position_shift)
                {
                    x = Cursor.Position.X;
                    y = Cursor.Position.Y;
                }

                if (cs == aim_reset || cs == aim_reset_shift)
                {
                    len = 236;
                    x = w / 2;
                    y = h / 2;
                    mode = 0;
                    angle = 85;
                    power = 100;
                    wind = 0;
                    first_portal_x = second_portal_x = first_portal_y = second_portal_y = 0;
                    portal_radius = 50;
                    lpower.Text = power.ToString() + "%";
                    langle.Text = angle.ToString() + "°";
                    lwind.Text = wind.ToString();
                }

                try
                {
                    if (cs == set_wind || cs == set_wind_shift)
                    {
                        wind = (Int32) Convert.ToInt16(Interaction.InputBox("Параметр ветра", "Ветер",
                            Convert.ToString(wind), (w / 2) - 170, (h / 2) - 50));
                        lwind.Text = wind.ToString();
                    }

                    if (cs == set_angle || cs == set_angle_shift)
                    {
                        angle = (Int32)Convert.ToInt16(Interaction.InputBox("Параметр угла", "Угол",
                            Convert.ToString(angle), (w / 2) - 170, (h / 2) - 50)) % 360;
                        langle.Text = angle.ToString();
                    }

                    if (cs == set_power || cs == set_power_shift)
                    {
                        power = Functions.LimitToRange((Int32) Convert.ToInt16(Interaction.InputBox("Параметр силы", "Сила",
                            Convert.ToString(power), (w / 2) - 170, (h / 2) - 50)), 0, 100, false);
                        lpower.Text = power.ToString() + "%";
                    }

                    if (cs == set_radius || cs == set_radius_shift)
                    {
                        len = (Int32) Convert.ToInt16(Interaction.InputBox("Радиус круга", "Радиус",
                            Convert.ToString(len), (w / 2) - 170, (h / 2) - 50));
                    }

                    if (cs == set_portal_radius)
                    {
                        portal_radius = (Int32)Convert.ToInt16(Interaction.InputBox("Параметр размера портала", "Портал",
                            Convert.ToString(portal_radius), (w / 2) - 170, (h / 2) - 50));
                    }

                }
                catch (Exception) { }

                if (cs == change_guidance_mode || cs == change_guidance_mode_shift)
                {
                    mode += (mode < maxmode) ? 1 : -mode;
                }
                if (cs == set_first_portal)
                {
                    first_portal_x = Cursor.Position.X;
                    first_portal_y = Cursor.Position.Y;
                }

                if (cs == set_second_portal)
                {
                    second_portal_x = Cursor.Position.X;
                    second_portal_y = Cursor.Position.Y;
                }

                if (cs == reset_portals)
                {
                    first_portal_x = first_portal_y = second_portal_x = second_portal_y = 0;
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
            lpower = new Label();
            langle = new Label();
            lwind = new Label();
            SuspendLayout();

            lpower.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lpower.BackColor = Color.FromArgb(75, 0, 0);
            lpower.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
            lpower.ForeColor = Color.FromArgb(255, 255, 255);
            lpower.Location = new Point(350, 360);
            lpower.Margin = new Padding(0);
            lpower.Name = "lpower";
            lpower.Size = new Size(150, 30);
            lpower.TabIndex = 0;
            lpower.TextAlign = ContentAlignment.MiddleCenter;

            langle.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            langle.BackColor = Color.FromArgb(0, 75, 0);
            langle.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
            langle.ForeColor = Color.FromArgb(255, 255, 255);
            langle.Location = new Point(350, 320);
            langle.Margin = new Padding(0);
            langle.Name = "langle";
            langle.Size = new Size(70, 30);
            langle.TabIndex = 1;
            langle.TextAlign = ContentAlignment.MiddleCenter;

            lwind.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lwind.BackColor = Color.FromArgb(0, 75, 75);
            lwind.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            lwind.ForeColor = Color.FromArgb(255, 255, 255);
            lwind.Location = new Point(430, 320);
            lwind.Margin = new Padding(0);
            lwind.Name = "lwind";
            lwind.Size = new Size(70, 30);
            lwind.TabIndex = 4;
            lwind.TextAlign = ContentAlignment.MiddleCenter;
            lwind.Visible = true;

            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(784, 412);
            Controls.Add((Control) langle);
            Controls.Add((Control) lpower);
            Controls.Add((Control) lwind);
            FormBorderStyle = FormBorderStyle.None;
            Name = nameof(Main_Form);
            Text = "Aim Version "+version.ToString();
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