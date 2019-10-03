using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentHouse.DTO
{
    public class HousePicDTO : BaseDTO
    {
        public long HouseId { get; set; }
        public String Url { get; set; }
        public String ThumbUrl { get; set; }  //缩略图 url
    }
}
