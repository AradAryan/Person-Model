using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
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
                FirstName = "آراد",
                FollowUp = new Guid(),
                Gender = 0,
                Id = 0151067030,
                IsDead = false,
                LastName = "آریایی",
                NationalCode = 01510670030,
            };

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
            System.IO.File.AppendAllText(@"D:\SepamFTP.txt", "13: " + model.NationalCode + "\r" + "\n");

            // var temp = new Bitmap(Person_Model.Properties.Resources.correct);//(Bitmap.FromFile(@"C:\Users\faranam\source\Repos\Person Model\Person Model\Resource1\correct.jpg"));
            Bitmap bitMapImage = new Bitmap(@"C:\Users\faranam\Desktop\kartMelii.png"); //Resource1.kartMeli;

              Graphics graphicImage = Graphics.FromImage(bitMapImage);

            ///کد ملی
            graphicImage.AddText(model.NationalCode > 0 ? model.NationalCode.ToString("0000000000") : "", new Font(Font.FontFamily, 15, FontStyle.Regular)/*NationalCodeFont*/, Brushes.Maroon, 650, 82);
            graphicImage.AddText(model.FirstName, new Font(Font.FontFamily, 15, FontStyle.Regular)/*MainFont*/, Brushes.Black, 730, 1150);
            graphicImage.AddText(model.LastName, new Font(Font.FontFamily, 15, FontStyle.Regular)/*MainFont*/, Brushes.Black, 660, 175);
            //سال تولد به عدد
            graphicImage.AddText(model.BirthDate > 0 ? model.BirthDate.ToString("0000/00/00") : "", new Font(Font.FontFamily, 15, FontStyle.Regular) /*DetialsFont*/, Brushes.Black, 679, 219);
            //   graphicImage.AddText((model.IdentityNo != "0") ? model.IdentityNo : "", new Font(Font.FontFamily, 15, FontStyle.Regular) /*MainFont*/, Brushes.Black, 6159, 250);
            //نام پدر
            graphicImage.AddText(model.FatherName, new Font(Font.FontFamily, 15, FontStyle.Regular) /*FatherNameFont*/, Brushes.Black, 695, 290);
            //نام پدر
            graphicImage.AddText((model.NationalCode > 0) ? model.IsDead ? "(فوت شده)" : "زنده" : "", new Font(Font.FontFamily, 15, FontStyle.Regular) /*FatherNameFont*/, Brushes.Black, 660, 323);
            //وضعیت حیات
            graphicImage.AddText(model.Almosana ? "(المثنی)" : "اصل", new Font(Font.FontFamily, 15, FontStyle.Regular) /*FatherNameFont*/, Brushes.Black, 629, 397);


            //روز به حروف
            graphicImage.AddText((model.Serial != "0") ? string.Format("{0} / {1}", model.Seri, model.Serial) : "", new Font(Font.FontFamily, 15, FontStyle.Regular) /*NationalCodeFont*/, Brushes.Maroon, 580, 360);

            graphicImage.AddText(model.ZipCode, new Font(Font.FontFamily, 15, FontStyle.Regular)/* FatherNameFont*/, Brushes.Black, 685, 1532);

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
            graphicImage.AddText(model.FollowUp.ToString(), new Font(Font.FontFamily, 15, FontStyle.Regular)/* DetialsFont*/, Brushes.Black, 300, 605);
            //FollowUp(graphicImage, model.FollowUp.ToString());
            //تاریخ درخواست
            graphicImage.AddText("تاریخ استعلام : " + "1398/11/11", new Font(Font.FontFamily, 15, FontStyle.Regular) /* DetialsFont*/, Brushes.Black, 230, 575);
            //پیام
            if (model.Message != null)
            {

                graphicImage.AddText(model.Message.ToString(), new Font(Font.FontFamily, 15, FontStyle.Regular)/* MessageFont*/, Brushes.Maroon, 370, 1530);
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

    }
}
