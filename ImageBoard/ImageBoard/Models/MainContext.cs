using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageBoard.Models
{
    public class MainContext: DbContext 
    {
        public DbSet<Theme> Themes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Profile> Profiles { get; set; }
    }

    //=========[опции поста/темы]===============
    public class Option
    {
        [Key]
        public int Id { get; set; }
        public bool Lock { get; set; }
        public bool Star { get; set; }

    }


    //===========[модель поста]=================
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(24)]
        public string PostName { get; set; }

        [MaxLength(255)]
        public string PostBody { get; set; }

        [Range(0, 5)]
        public int Star { get; set; }
        public DateTime DateCreate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }


    //============[модель темы]==================
    public class Theme
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(24)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string ThemeBody { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime DateCreated { get; set; }

        private ICollection<Post> posts;
        public virtual ICollection<Post> Posts
        {
            get { return posts ?? (posts = new Collection<Post>()); }
            set { posts = value; }
        }
        public int OptionId { get; set; }
        public Option Option { get; set; }

        public int CountPost { get; set; }
        public int CountFile { get; set; }
        public int CountUserSee { get; set; }

    }


    //============[модель пользователя]===============
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Имя Пользователя")]
        [MaxLength(24, ErrorMessage = "Превышена максимальная длина записи")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Password { get; set; }

        public string Salt { get; set; }

        [Required]
        [Display(Name = "Дата Создания")]
        public DateTime DateCreated { get; set; }

        [Required]
        [Display(Name = "Политика")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        [Required]
        [Display(Name = "Тема")]
        private ICollection<Theme> themes;
        public virtual ICollection<Theme> Themes
        {
            get { return themes ?? (themes = new Collection<Theme>()); }
            set { themes = value; }
        }
        private ICollection<Post> posts;
        public virtual ICollection<Post> Posts
        {
            get { return posts ?? (posts = new Collection<Post>()); }
            set { posts = value; }
        }
        [Required]
        [Display(Name = "Профиль")]
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        private ICollection<User> _followings;
        public virtual ICollection<User> Followings
        {
            get { return _followings ?? (_followings = new Collection<User>()); }
            set { _followings = value; }
        }

        private ICollection<User> _followers;
        public virtual ICollection<User> Followers
        {
            get { return _followers ?? (_followers = new Collection<User>()); }
            set { _followers = value; }
        }
    }

    //===============[Модель ролей]========================
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    //===============[Модель профиля]======================
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        [MaxLength(20, ErrorMessage = "Превышена максимальная длина записи")]
        public string SubName { get; set; }

        [Required]
        [Display(Name = "Имя")]
        [MaxLength(20, ErrorMessage = "Превышена максимальная длина записи")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Пол")]
        public bool Sex { get; set; }

        [Required]
        [Display(Name = "Дата Рождения")]
        public DateTime Birthday { get; set; }
    }
}