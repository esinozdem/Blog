using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IMessage2Service: IGenericService<Message2>
    {
        //Yazara göre veri getirecek metot.
        List<Message2> GetInboxListWithByWriter(int id);

       
    }
}
