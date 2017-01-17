using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiceForImages.MyDB;

namespace ServiceForImages.Controllers
{
    public class ManageImagesController : ApiController
    {

        ServiceForImagesDBEntities db = new ServiceForImagesDBEntities();

        [AcceptVerbs("GET","POST")]
        public string ImageInString(string ImageData)
        {
            StoreImageInString st = new StoreImageInString();
            st.ImgData = ImageData;
            db.StoreImageInStrings.Add(st);
            db.SaveChanges();
            return "status={Record Saved}";
        }

        [AcceptVerbs("GET", "POST")]
        public string ImageInBinary(byte[] ImageData)
        {
            StoreImageInBinary st = new StoreImageInBinary();
            st.ImgData = ImageData;
            db.StoreImageInBinaries.Add(st);
            db.SaveChanges();
            return "status={Record Saved}";
        }

        [AcceptVerbs("GET", "POST")]
        public List<StoreImageInString> AllImagesInStringFormat()
        {
            return db.StoreImageInStrings.ToList();
        }

        [AcceptVerbs("GET", "POST")]
        public List<StoreImageInBinary> AllImagesInBinaryFormat()
        {
            return db.StoreImageInBinaries.ToList();
        }

        //[HttpPost]
        //public string PostNewImageWIthString(string ImageData)
        //{
        //    StoreImageInString st = new StoreImageInString();
        //    st.ImgData = ImageData;
        //    db.StoreImageInStrings.Add(st);
        //    db.SaveChanges();
        //    return "status={Record Saved}";
        //}
    }
}
