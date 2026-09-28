using System;
using System.Collections.Generic;
using System.Text;
using YalcinHotel_Entity;

namespace YalcinHotel_BLL.Abstract
{
    public interface IRoomService : IRepositoryService<Room>
    {
        List<Room> GetPopularAll();
    }
}
