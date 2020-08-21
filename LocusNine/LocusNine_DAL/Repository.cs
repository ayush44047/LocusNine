using LocusNine_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocusNine_DAL
{
    public class Repository
    {

        private readonly LocusNineContext _context;
        public Repository(LocusNineContext context)
        {
            _context = context;
        }
        public Repository()
        {
            _context = new LocusNineContext();
        }



        public List<UserDetail> GetUsers()
        {
            try
            {
                List<UserDetail> userList = (from a in _context.Users
                                             join b in _context.Roles
                                             on a.Roleid equals b.Roleid
                                             select
                                            new UserDetail
                                            {
                                                Userid = a.Userid,
                                                Roleid = a.Roleid,
                                                Fullname = a.Fullname,
                                                Email = a.Email,
                                                Mobile = a.Mobile,
                                                Rolename = b.Rolename,

                                            }).ToList();
                return userList;
            }
            catch (Exception)
            {
                return null;

            }

        }

        public List<Roles> GetRoles()
        {
            List<Roles> rs ;
            try
            {
                rs = _context.Roles.ToList();
            }
            catch (Exception)
            {

                return null;
            }
            return rs;
        }


        public bool AddUser(UserDetail userDetail)
        {
            bool status = false;
            try
            {
                Users user = new Users
                {
                    Fullname = userDetail.Fullname,
                    Email = userDetail.Email,
                    Mobile = userDetail.Mobile,
                    Roleid = userDetail.Roleid

                };
                _context.Users.Add(user);
                _context.SaveChanges();
                status = true;

            }
            catch (Exception e)
            {

                status = false;
            }
            return status;
        }

        public bool UpdateUser(UserDetail userDetail)
        {
            bool status = false;
            try
            {
                Users ud = _context.Users.Find(userDetail.Userid);

                ud.Fullname = userDetail.Fullname;
                ud.Email = userDetail.Email;
                ud.Mobile = userDetail.Mobile;
                ud.Roleid = userDetail.Roleid;


                _context.Users.Update(ud);
                _context.SaveChanges();
                status = true;

            }
            catch (Exception)
            {

                status = false;
            }
            return status;
        }

        public bool DeleteUser(int userid)
        {
            bool status = false;
            try
            {
                Users ud = _context.Users.Find(userid);

                _context.Users.Remove(ud);
                _context.SaveChanges();
                status = true;

            }
            catch (Exception)
            {

                status = false;
            }
            return status;
        }

    }




}
