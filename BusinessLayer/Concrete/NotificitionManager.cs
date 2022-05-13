using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   
    public class NotificitionManager : INotificitionService
    {
        INotificitionDal _notificitionDal;

        public NotificitionManager(INotificitionDal notificitionDal)
        {
            _notificitionDal = notificitionDal;
        }

        public Notificition GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Notificition> GetList()
        {
           return _notificitionDal.GetListAll();
        }

        public void TAdd(Notificition t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Notificition t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Notificition t)
        {
            throw new NotImplementedException();
        }
    }
}
