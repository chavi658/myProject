using RestFull.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFull
{
    public class DataContex
    {
        public List<Guest> GuestList { get; set; }
        public List<Package> PackageList { get; set; }
        public List<Room> RoomList { get; set; }
        public DataContex()
        {
            GuestList = new List<Guest>();
            GuestList.Add(new Guest { Id = 1, Phone = 000, Status = 1 });
            PackageList = new List<Package>();
            PackageList.Add(new Package { PackageName="vip",Price=1000});
            RoomList = new List<Room>();
            RoomList.Add(new Room { Avialable = false, Id = 12 });
        }
    }
}
