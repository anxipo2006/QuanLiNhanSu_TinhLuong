using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace QuanLiNhanSu_TinhLuong
{
    public static class ThemeManager
    {
        // Color tokens
        private static readonly Color PrimaryBlue = ColorTranslator.FromHtml("#2563EB");
        private static readonly Color PrimaryBlueDark = ColorTranslator.FromHtml("#1D4ED8");
        private static readonly Color LightBlue = ColorTranslator.FromHtml("#DBEAFE");
        private static readonly Color Background = ColorTranslator.FromHtml("#F8FAFC");
        private static readonly Color White = ColorTranslator.FromHtml("#FFFFFF");
        private static readonly Color GrayBorder = ColorTranslator.FromHtml("#E2E8F0");
        private const int ButtonRadius = 12;
        private const int InputRadius = 8;

        // Entry point for applying the theme to a form at runtime
        public static void ApplyModernTheme(Form form)
        {
            if (form == null) return;

            // Form level
            form.BackColor = White;
            form.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);

            // Add borderless, shadow, elipse, animate components
            try
            {
                var shadow = new Guna2ShadowForm();
                shadow.TargetForm = form;

                var borderless = new Guna2BorderlessForm();
                borderless.ContainerControl = form;
                borderless.ResizeForm = true;
                borderless.DockIndicatorTransparencyValue = 0.6D;
                borderless.TransparentWhileDrag = true;

                var el = new Guna2Elipse();
                el.TargetControl = form;
                el.BorderRadius = 12;

                var anim = new Guna2AnimateWindow();
                anim.TargetForm = form;
                anim.AnimationType = Guna2AnimateWindow.AnimateWindowType.AW_BLEND;
                anim.Interval = 200;
            }
            catch
            {
                // ignore component creation failures
            }

            // Replace or restyle controls recursively
            var all = GunaUiStyler.GetAllControls(form).ToList();
            foreach (Control c in all)
            {
                // Panels -> Guna2Panel
                if (c is Panel && !(c is Guna2Panel)) ReplaceControlWith<Guna2Panel>(form, c, p =>
                {
                    p.FillColor = White;
                    p.ShadowDecoration.Enabled = true;
                });

                // Buttons -> Guna2Button
                else if (c is Button && !(c is Guna2Button)) ReplaceControlWith<Guna2Button>(form, c, b =>
                {
                    b.BorderRadius = ButtonRadius;
                    b.FillColor = PrimaryBlue;
                    b.ForeColor = White;
                    b.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
                    b.Animated = true;
                    b.HoverState.FillColor = PrimaryBlueDark;
                    b.ShadowDecoration.Enabled = false;
                });

                // TextBox -> Guna2TextBox
                else if (c is TextBox && !(c is Guna2TextBox)) ReplaceControlWith<Guna2TextBox>(form, c, t =>
                {
                    t.BorderRadius = InputRadius;
                    t.BorderColor = GrayBorder;
                    t.FillColor = White;
                    t.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
                    t.FocusedState.BorderColor = PrimaryBlue;
                });

                // ComboBox
                else if (c is ComboBox && !(c is Guna2ComboBox)) ReplaceControlWith<Guna2ComboBox>(form, c, cb =>
                {
                    cb.BorderRadius = InputRadius;
                    cb.BorderColor = GrayBorder;
                    cb.FillColor = White;
                    cb.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
                    cb.FocusedColor = PrimaryBlue;
                });

                // DateTimePicker
                else if (c is DateTimePicker && !(c is Guna2DateTimePicker)) ReplaceControlWith<Guna2DateTimePicker>(form, c, dt =>
                {
                    dt.BorderRadius = InputRadius;
                    dt.BorderColor = GrayBorder;
                    dt.FillColor = White;
                    dt.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
                    dt.FocusedColor = PrimaryBlue;
                });

                // PictureBox
                else if (c is PictureBox && !(c is Guna2PictureBox)) ReplaceControlWith<Guna2PictureBox>(form, c, pb =>
                {
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.BorderRadius = 8;
                });

                // DataGridView -> Guna2DataGridView
                else if (c is DataGridView && !(c is Guna2DataGridView)) ReplaceDataGridView(form, c as DataGridView);
            }

            // After replacements, style any remaining Guna2 controls
            foreach (var g in GunaUiStyler.GetAllControls(form).OfType<Guna2Button>())
            {
                g.BorderRadius = ButtonRadius;
                g.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
                if (g.FillColor == Color.Empty || g.FillColor == Color.Transparent)
                {
                    g.FillColor = PrimaryBlue;
                    g.ForeColor = White;
                }
                g.HoverState.FillColor = PrimaryBlueDark;
                g.Animated = true;
            }

            foreach (var t in GunaUiStyler.GetAllControls(form).OfType<Guna2TextBox>())
            {
                t.BorderRadius = InputRadius;
                t.BorderColor = GrayBorder;
                t.FillColor = White;
                t.FocusedState.BorderColor = PrimaryBlue;
            }

            foreach (var dgv in GunaUiStyler.GetAllControls(form).OfType<Guna2DataGridView>())
            {
                GunaUiStyler.StyleDataGrid(dgv);
            }
        }

        private static void ReplaceDataGridView(Form form, DataGridView old)
        {
            if (old == null) return;
            var parent = old.Parent;
            int idx = parent.Controls.GetChildIndex(old);

            var ndgv = new Guna2DataGridView();
            CopyCommonProperties(old, ndgv);
            // attempt to preserve data source and columns
            try { ndgv.DataSource = old.DataSource; } catch { }
            try
            {
                foreach (DataGridViewColumn col in old.Columns)
                {
                    var clone = (DataGridViewColumn)col.Clone();
                    ndgv.Columns.Add(clone);
                }
            }
            catch { }

            ndgv.ThemeStyle.HeaderStyle.BackColor = PrimaryBlue;
            ndgv.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            ndgv.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            ndgv.RowTemplate.Height = Math.Max(36, old.RowTemplate.Height);

            parent.Controls.Add(ndgv);
            parent.Controls.SetChildIndex(ndgv, idx);
            parent.Controls.Remove(old);

            // set backing field on form if exists
            var fld = form.GetType().GetField(old.Name, BindingFlags.NonPublic | BindingFlags.Instance);
            if (fld != null) fld.SetValue(form, ndgv);
        }

        private static void ReplaceControlWith<TTarget>(Form form, Control old, Action<TTarget> configure)
            where TTarget : Control, new()
        {
            if (old == null) return;
            var parent = old.Parent;
            int idx = parent.Controls.GetChildIndex(old);

            var target = new TTarget();
            CopyCommonProperties(old, target);
            try { configure?.Invoke(target); } catch { }

            parent.Controls.Add(target);
            parent.Controls.SetChildIndex(target, idx);
            parent.Controls.Remove(old);

            // copy event handlers (best effort)
            TryCopyEventHandlers(old, target);

            // set backing field on form if exists
            var fld = form.GetType().GetField(old.Name, BindingFlags.NonPublic | BindingFlags.Instance);
            if (fld != null)
            {
                try { fld.SetValue(form, target); }
                catch { }
            }
        }

        private static void TryCopyEventHandlers(Control src, Control dst)
        {
            try
            {
                var eventsProp = typeof(Component).GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
                var srcList = eventsProp.GetValue(src);
                if (srcList != null)
                {
                    eventsProp.SetValue(dst, srcList);
                }
            }
            catch
            {
                // swallow
            }
        }

        private static void CopyCommonProperties(Control src, Control dst)
        {
            dst.Name = src.Name;
            dst.Text = src.Text;
            dst.Location = src.Location;
            dst.Size = src.Size;
            dst.Anchor = src.Anchor;
            dst.Dock = src.Dock;
            dst.TabIndex = src.TabIndex;
            dst.Visible = src.Visible;
            dst.Enabled = src.Enabled;
            try { dst.Font = src.Font; } catch { }
            try { dst.BackColor = src.BackColor; } catch { }
            try { dst.ForeColor = src.ForeColor; } catch { }
        }
    }
}
