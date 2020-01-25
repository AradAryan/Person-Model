using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Person_Model
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Bitmap bitMapImage = new Bitmap(@"C:\Users\faranam\Desktop\Final Card.png");
        private void Form1_Load(object sender, EventArgs e)
        {
            var p = new PersonInfoModel();
            p = new PersonInfoModel
            {
                Almosana = false,
                BirthDate = 13780825,
                DeathDate = "Unknonw",
                FatherName = "حجت الله",
                FirstName = "محمدجواد",
                FollowUp = new Guid(),
                Gender = 0,
                Id = 0151067030,
                IsDead = false,
                LastName = "عرب سلمانی",
                NationalCode = 0410670030,
                Message = "کارگران مشغول کارند.",
                IsValid = true,
            };

            pictureBox1.Image = CreateResponse(p);

            //  CreateResponse(p);

        }


        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        public Image CreateResponse(PersonInfoModel model)
        {
            File.AppendAllText(@"D:\SepamFTP.txt", "13: " + model.NationalCode + "\r" + "\n");

            //Resource1.kartMeli;

            Graphics graphicImage = Graphics.FromImage(bitMapImage);

            //Select your font from the resources.
            PrivateFontCollection pfc = new PrivateFontCollection();
            //My font here is "Digireu.ttf"
            int fontLength = Properties.Resources.BYekan.Length;

            // create a buffer to read in to
            byte[] fontdata = Properties.Resources.BYekan;

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            pfc.AddMemoryFont(data, fontLength);


            Font MainFont = new Font(pfc.Families[0], 20, FontStyle.Regular);
            Font InsertsFont = new Font(pfc.Families[0], 70, FontStyle.Regular);
            ///کد ملی
            graphicImage.AddText(model.NationalCode > 0 ? ImageTools.ConvertIntToString((Int32)model.NationalCode) : "", MainFont/*NationalCodeFont*/, Brushes.Black, 650, 121);
            graphicImage.AddText(model.FirstName, MainFont, Brushes.Black, 650, 170);
            graphicImage.AddText(model.LastName, MainFont, Brushes.Black, 650, 215);
            //سال تولد به عدد
            graphicImage.AddText(model.BirthDate > 0 ? ImageTools.ConvertIntToString((Int32)model.BirthDate) : "", MainFont /*DetialsFont*/, Brushes.Black, 650, 260);
            //   graphicImage.AddText((model.IdentityNo != "0") ? model.IdentityNo : "", font /*MainFont*/, Brushes.Black, 6159, 250);
            //نام پدر
            graphicImage.AddText(model.FatherName, MainFont /*FatherNameFont*/, Brushes.Black, 650, 305);
            //وضعیت حیات
            //  graphicImage.AddText((model.NationalCode > 0) ? model.IsDead ? "(فوت شده)" : "" : "", MainFont /*FatherNameFont*/, Brushes.Black, 650, 318);
            //تاریخ درخواست
            //  graphicImage.AddText("تاریخ استعلام : " + "1398/11/11", font /* DetialsFont*/, Brushes.Black, 655, 400);

            //المثنی / اصل
            //  graphicImage.AddText(model.Almosana ? "(المثنی)" : "اصل", font /*FatherNameFont*/, Brushes.Black, 629, 397);




            //روز به حروف
            // graphicImage.AddText((model.Serial != "0") ? string.Format("{0} / {1}", model.Seri, model.Serial) : "", font /*NationalCodeFont*/, Brushes.Maroon, 580, 360);

            //  graphicImage.AddText(model.ZipCode, font/* FatherNameFont*/, Brushes.Black, 685, 1532);

            ////روز به حروف
            //graphicImage.AddText(model.DateString[2], DetialsFont, Brushes.Black, 1578, 1560);
            ////ماه به حروف
            //graphicImage.AddText(model.DateString[1], DetialsFont, Brushes.Black, 366, 1560);
            ////سال به حروف
            //graphicImage.AddText(model.DateString[0], DetialsFont, Brushes.Black, 1592, 1587);

            ////روز به قمری
            //graphicImage.AddText(model.DateString[5], DetialsFont, Brushes.Black, 1579, 5158);
            ////ماه به قمری
            //graphicImage.AddText(model.DateString[15], DetialsFont, Brushes.Black, 1529, 5158);
            ////سال به قمری
            //graphicImage.AddText(model.DateString[3], DetialsFont, Brushes.Black, 328, 5158);

            //کد پیگیری
            //  graphicImage.AddText(model.FollowUp.ToString(), font/* DetialsFont*/, Brushes.Black, 300, 605);
            //FollowUp(graphicImage, model.FollowUp.ToString());

            Bitmap personImage = new Bitmap(@"C:\Users\faranam\Desktop\personalImage.png");

            ImageTools.InsertImage(graphicImage, ImageTools.MakeGrayscale(personImage));
            //پیام
            if (model.Message != null)
            {

                graphicImage.AddText(model.Message.ToString(), MainFont/* MessageFont*/, Brushes.Maroon, 650, 360);
            }

            /*    IsMan(graphicImage, model.Gender);
                if (model.PersonalImage != null)
                    if (model.PersonalImage.Image != null)
                        graphicImage.InsertImage(model.PersonalImage.Image);
                if (model.IsDead)
                    IsDead(graphicImage, "باطل شد", model.DeathDate); */
            //  MemoryStream mem = new MemoryStream();
            //   bitMapImage.Save(mem, ImageFormat.Jpeg);
            // var value = Convert.ToBase615String(mem.ToArray());
            //  graphicImage.Dispose();
            //   bitMapImage.Dispose();
            //  System.IO.File.AppendAllText(@"D:\SepamFTP.txt", "115: " + model.NationalCode + "\r" + "\n");
            if (model.IsDead)
            {
                graphicImage.AddText(model.IsDeadToString, InsertsFont /*FatherNameFont*/, Brushes.Maroon, 300, 120);
                graphicImage.DrawRectangle(new Pen(Brushes.Maroon, 5), new Rectangle(30, 125, 260, 80));
            }

            if (!model.IsValid)
            {
                graphicImage.AddText("باطل", InsertsFont /*FatherNameFont*/, Brushes.Maroon, 250, 220);
                graphicImage.DrawRectangle(new Pen(Brushes.Maroon, 5), new Rectangle(100, 225, 140, 85));
            }
            if (model.Almosana)
            {
                graphicImage.AddText(model.Almosana ? "المثنی" : "  اصل", InsertsFont /*FatherNameFont*/, Brushes.LightSlateGray, 200, 400, -45);
                graphicImage.DrawRectangle(new Pen(Brushes.LightSlateGray, 5), new Rectangle(0, 400, 200, 100));
            }
            return bitMapImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bitMapImage = new Bitmap(@"C:\Users\faranam\Desktop\Final Card.png");
            var p = new PersonInfoModel();
            p = new PersonInfoModel
            {
                Almosana = true,
                BirthDate = 13780825,
                DeathDate = "Unknonw",
                FatherName = "حجت الله",
                FirstName = "محمدجواد",
                FollowUp = new Guid(),
                Gender = 0,
                Id = 0151067030,
                IsDead = false,
                LastName = "عرب سلمانی",
                NationalCode = 0410670030,
                Message = "کارگران مشغول کارند.",
                IsValid = true,
            };

            if (checkBox3.Checked)
                p.IsDead = true;
            else
                p.IsDead = false;

            if (checkBox1.Checked)
                p.Almosana = true;
            else
                p.Almosana = false;

            if (checkBox2.Checked)
                p.IsValid = false;
            else
                p.IsValid = true;

            pictureBox1.Image = CreateResponse(p);
        }
    }

    public static class ImageTools
    {

        public static void AddText(this Graphics graph, string Text, Font font, Brush brush, int x, int y)
        {
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            graph.RotateTransform(0);
            graph.DrawString(Text, font, brush, new Point(x, y), format);
        }

        public static void AddText(this Graphics graph, string Text, Font font, Brush brush, int x, int y, int rotate)
        {
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            graph.RotateTransform(rotate);
            graph.DrawString(Text, font, brush, new Point(x, y), format);
        }

        public static void InsertImage(this Graphics graphicImage, byte[] Image)
        {
            using (MemoryStream mem = new MemoryStream(Image))
            {
                Bitmap Photo = new System.Drawing.Bitmap(mem);
                graphicImage.DrawImage(Photo, new Rectangle(70, 90, 180, 197));
            }
        }

        public static void InsertImage(this Graphics graphicImage, Bitmap bitmapImage)
        {
            graphicImage.DrawImage(bitmapImage, new Rectangle(50, 90, 220, 265));
        }

        public static Bitmap MakeGrayscale(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            using (Graphics g = Graphics.FromImage(newBitmap))
            {

                //create the grayscale ColorMatrix
                ColorMatrix colorMatrix = new ColorMatrix(
                   new float[][]
                   {
             new float[] {.3f, .3f, .3f, 0, 0},
             new float[] {.59f, .59f, .59f, 0, 0},
             new float[] {.11f, .11f, .11f, 0, 0},
             new float[] {0, 0, 0, 1, 0},
             new float[] {0, 0, 0, 0, 1}
                   });

                //create some image attributes
                using (ImageAttributes attributes = new ImageAttributes())
                {

                    //set the color matrix attribute
                    attributes.SetColorMatrix(colorMatrix);

                    //draw the original image on the new image
                    //using the grayscale color matrix
                    g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                                0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
                }
            }
            return newBitmap;
        }
        public static string ConvertIntToString(int value)
        {
            int counter;
            string input;
            string output = "";

            if (value.ToString().Length == 9)
            {
                counter = 10;
                input = value.ToString("0000000000");
            }
            else
            {
                counter = 8;
                input = value.ToString("00000000");
            }

            string[] numbers =
                { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };

            for (int i = 0; i < counter; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (input.StartsWith(j.ToString()))
                    {
                        output += numbers[j];
                        break;
                    }
                }
                if (input.Length == 0)
                {
                    return output;
                }
                input = input.Remove(0, 1);
            }

            if (counter != 10)
            {
                output = output.Insert(4, "/");
                output = output.Insert(7, "/");
            }

            return output;
        }
    }
}
