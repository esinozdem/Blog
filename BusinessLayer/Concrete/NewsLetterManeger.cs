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
    public class NewsLetterManeger : INewsLetterService
    {
        INewsLetterDal _newsLetterDal;
        public NewsLetterManeger(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }
        public void AddNewsLetter(NewsLetter newsLetter)
        {
            _newsLetterDal.Insert(newsLetter);
        }
    }
}
