using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFID_Attendance_Project.UserControls;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp;

namespace RFID_Attendance_Project
{
    public partial class PopGenerateDTR : Form
    {
        public PopGenerateDTR()
        {
            InitializeComponent();
            dateTimePicker.MaxDate = DateTime.Today;
            dateTimePicker.Value = DateTime.Today;
        }

        public static string generate_month;
        public static string generate_year;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker.Value;

            string selectedMonth = selectedDate.ToString("MMMM");
            string selectedYear = selectedDate.ToString("yyyy");

            generate_month = selectedMonth;
            generate_year = selectedYear;

            Console.WriteLine($"{generate_month} : {generate_year}");

            DTR_Format uc = new DTR_Format();
            addUserControl(uc);
            btnExport.Enabled = true;
        }

        private void addUserControl(UserControl UserControls)
        {
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(UserControls);
            UserControls.BringToFront();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            UserControl activeControl = (UserControl)panelContainer.Controls[0];

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            saveFileDialog.Title = "Save PDF File";
            saveFileDialog.FileName = $"{FormLogin.username_display} {generate_month} {generate_year}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ConvertToPdf(activeControl, saveFileDialog.FileName);
            }
        }

        public void ConvertToPdf(UserControl userControl, string outputPath)
        {
            Bitmap bitmap = new Bitmap(userControl.Width, userControl.Height);

            // Draw child controls in reverse order onto the bitmap
            for (int i = userControl.Controls.Count - 1; i >= 0; i--)
            {
                Control control = userControl.Controls[i];
                control.DrawToBitmap(bitmap, control.Bounds);
            }

            byte[] imageBytes;
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                imageBytes = stream.ToArray();
            }

            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            page.Size = PageSize.Legal;
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XImage image = XImage.FromStream(new MemoryStream(imageBytes));
            gfx.DrawImage(image, 0, 0);

            document.Save(outputPath);
            document.Close();

            bitmap.Dispose();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            btnExport.Enabled = false;
        }
    }
}
