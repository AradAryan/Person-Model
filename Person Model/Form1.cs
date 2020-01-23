using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Person_Model
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // static Bitmap temp = new Bitmap(Person_Model.Properties.Resources.correct);//(Bitmap.FromFile(@"C:\Users\faranam\source\Repos\Person Model\Person Model\Resource1\correct.jpg"));
        //  static Bitmap bitMapImage = temp;  //Resource1.kartMeli;
        //  static Graphics graphicImage = Graphics.FromImage(bitMapImage);
        private void Form1_Load(object sender, EventArgs e)
        {
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
            };
            //  MessageBox.Show(ImageTools.ConvertIntToString((Int32)p.NationalCode));
            pictureBox1.Image = CreateResponse(p);



            //  CreateResponse(p);

            //  var temp = new Bitmap(Person_Model.Properties.Resources.correct);
            //(Bitmap.FromFile(@"C:\Users\faranam\source\Repos\Person Model\Person Model\Resource1\correct.jpg"));
            //   Bitmap bitMapImage = temp;  //Resource1.kartMeli;
            //    Graphics graphicImage = Graphics.FromImage(bitMapImage);

            //    ImageTools.InsertImage(graphicImage, ImageToByteArray(temp));
            //   BackgroundImage = bitMapImage;
        }


        ///////////////
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        ////////////
        public Image CreateResponse(PersonInfoModel model)
        {
            File.AppendAllText(@"D:\SepamFTP.txt", "13: " + model.NationalCode + "\r" + "\n");

            Bitmap bitMapImage = new Bitmap(@"C:\Users\javad\Desktop\Final Card.png"); //Resource1.kartMeli;

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
            graphicImage.AddText((model.NationalCode > 0) ? model.IsDead ? "(فوت شده)" : "" : "", MainFont /*FatherNameFont*/, Brushes.Black, 650, 318);
            //تاریخ درخواست
            //  graphicImage.AddText("تاریخ استعلام : " + "1398/11/11", font /* DetialsFont*/, Brushes.Black, 655, 400);

            //المثنی / اصل
            //  graphicImage.AddText(model.Almosana ? "(المثنی)" : "اصل", font /*FatherNameFont*/, Brushes.Black, 629, 397);

            graphicImage.AddText(model.Almosana ? "المثنی" : "اصل", new Font(Font.FontFamily, 80, FontStyle.Bold) /*FatherNameFont*/, Brushes.LightSlateGray, 200, 400, -45);


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

            //پیام
            if (model.Message != null)
            {

                graphicImage.AddText(model.Message.ToString(), MainFont/* MessageFont*/, Brushes.Maroon, 370, 1530);
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


            return bitMapImage;
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

        public static string ConvertIntToString(int value)
        {
            int counter;
            string output = "";
            string input;
            if (value.ToString().Length == 9)
            {
                input = value.ToString("0000000000");
                counter = 10;
            }
            else
            {
                input = value.ToString("00000000");
                counter = 8;
            }
            string[] numbers = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };

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
                    return output;
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
