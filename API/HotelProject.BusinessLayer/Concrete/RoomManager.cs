using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class RoomManager : GenericManager<Room>, IRoomService
    {
        public RoomManager(IGenericDal<Room> genericDal) : base(genericDal)
        {
        }
    }
}
