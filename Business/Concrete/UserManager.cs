using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(user.UserEmail);
            if (user.UserEmail.Length < 5)
            {   
                return new ErrorResult("Email minimum 5 karakter olabilir");
            }
            if (match.Success == false)
            {
                return new ErrorResult("Email formatı uygun değil");
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("Kullanıcı silindi");
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), "Kullanıcılar listelendi");
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId), "Kullanıcı numarasına göre data getirildi.");
        }


        public IResult Login(string email, string password)
        {
            var result = _userDal.Get(u => u.UserEmail == email && u.UserPassword == password);
            if(result == null)
            {
                return new ErrorDataResult<User>("Kullanıcı adı veya şifre hatalı");
            }
            return new SuccessDataResult<User>("Giriş başarılı");
        }

        public IResult CheckEmail(string email)
        {
            var result = _userDal.Get(u => u.UserEmail == email);
            if (result == null) 
            {
                return new SuccessResult();
            }
            else if (result.UserEmail == email)
            {
                return new ErrorResult("Email adresiniz başka bir kullanıcıya ait.");
            }
            return new SuccessResult();
        }

        public IResult Update(User user)
        {
            try
            {
                _userDal.Update(user);
                return new SuccessResult("Güncelleme başarılı.");
            }
            catch (Exception)
            {
                return new ErrorResult("Tüm bilgileri eksiksiz giriniz.");
                throw;
            }

        }
    }
}
