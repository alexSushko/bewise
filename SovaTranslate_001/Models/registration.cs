using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace SovaTranslate_001.Models
{
    public class Report{
        public int month;
        public int summarycost{get;set;}
        public List<order> ord{get;set;}
        public int countuser{get;set;}
        public int countmanager{get;set;}
        public int countoperator{get;set;}
        public int countadmin{get;set;}
    }
    public class AddTranslatorT {
        public List<int> specializationTr { get; set; }
        public int IdUser { get; set; }
        public string specializationTrAdd { get; set; }
        public bool isL { get; set; }
        public int complexity{ get; set; }
        public double pricespec { get; set; }
        public List<double> price { get; set; }
       

    }
    public class orderTranslators {
        public int order;
        public List<translator> translators;
        public int idTranslator; public orderTranslators() { }
        public orderTranslators(int order, List<translator> translators) {
            this.order = order;
            this.translators = translators;
        }
    }
    public class RegisterApplicationForm:IValidatableObject
    {
        public string name { get; set; }
        public string description { get; set; }
        public DateTime deadline { get; set; }
        public HttpPostedFileBase[] UploadedFiles { get; set; }
        public string text { get; set; }
        public int  Language { get; set;}
        public int[] spec { get; set; }
       
        public int userId { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //if(!string.IsNullOrEmpty(Language)){
            //     yield return new ValidationResult("Выбирите язык перевода", new string[] { "language" });
            
            //}
            
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (name.Length <= 3 || name.Length > 15)
                {
                    yield return new ValidationResult("Название должно быть больше 3 и меньше 15 символов", new string[] { "name" });
                }
            }
            if (!string.IsNullOrWhiteSpace(description))
            {
                if (description.Length <= 5 || description.Length > 50)
                {
                    yield return new ValidationResult("Описание должно быть больше 5 и меньше 50 символов", new string[] { "description" });
                }
            }
            if (deadline < DateTime.Now) {
                yield return new ValidationResult("Конечная дата не может быть меньше сегодняшней", new string[] { "deadline" });
            }


            if (UploadedFiles != null&&UploadedFiles[0]!=null)
            {
                bool flag = false;
                foreach (var UploadedFile in UploadedFiles)
                {
                    switch (UploadedFile.ContentType.ToString())
                    {
                        case "text/plain":
                        case "application/msword":
                        case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                        case "image/jpg":
                        case "image/jpeg":
                        case "image/png":
                        case "application/pdf":
                            flag = true;
                            break;

                    }
                    if (!flag) yield return new ValidationResult("Документ должен быть соответствующего типа(doc,docx,jpeg,jpg,png,pdf)", new string[] { "UploadedFile" });
                }
            }
            else {
                if (text == null || text.Length < 5) {
                    yield return new ValidationResult("Заполните текст для перевода(или ссылку) или загрузите документ", new string[] { "text" });
                }
            }
            
        }
    }




    public class AuthModel : IValidatableObject
    {

        public bool isError = false;
        public string email { get; set; }

                public string password { get; set; }

       // public Ad[] Ads {get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            Regex reg = new Regex(@"\W");
            sovadb001Entities0 db = new sovadb001Entities0();
            //Не нулевой Email
            if (string.IsNullOrWhiteSpace(email))
            {
                yield return new ValidationResult("Введите email", new string[] { "email" });
            }
            else
            {
                //корректный Email
                var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.Compiled);
                var match = regex.Match(email);
                //if (reg.IsMatch(email))
                //{
                //    yield return new ValidationResult("Символы запрещены", new string[] { "email" });
                //}
                if (!(match.Success && match.Length == email.Length))
                {
                    yield return new ValidationResult("Введите корректный email", new string[] { "email" });
                }
                
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                yield return new ValidationResult("Введите пароль", new string[] { "password" });
            }
            else
            {
                if (password.Length < 5 || password.Length > 15)
                {
                    yield return new ValidationResult("Пароль должен быть больше 5 и меньше 15 символов", new string[] { "password" });
                }
            }
        }
    }

    public class registration : IValidatableObject
    {
       // public int ID { get; set; }
        public string name { get; set; }
        //public string phonenumber { }
        //[Required(ErrorMessage = "Введите email")]
        public string email { get; set; }

       // [Required(ErrorMessage = "Введите пароль")]
        public string password { get; set; }

        //[Compare("password", ErrorMessage = "Пароли должны совпадать")]
        public string ConfirmPassword { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
             Regex reg = new Regex(@"\W");
            sovadb001Entities0 db = new sovadb001Entities0();
            //Не нулевой Email
            if (string.IsNullOrWhiteSpace(email))
            {
                yield return new ValidationResult("Введите email", new string[] { "email" });
            }
            else
            {
                //корректный Email
                var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.Compiled);
                var match = regex.Match(email);
                //if (reg.IsMatch(email))
                //{
                //    yield return new ValidationResult("Символы запрещены", new string[] { "email" });
                //}
                if (!(match.Success && match.Length == email.Length))
                {
                    yield return new ValidationResult("Введите корректный email", new string[] { "email" });
                }
                var anyUser = db.users.Any(p => string.Compare(p.email, email) == 0);
                if (anyUser)
                {
                    yield return new ValidationResult("Такой email уже зарегистрирован", new string[] { "email" });
                }
            }
            //пароль не нулевой
            if (string.IsNullOrWhiteSpace(password))
            {
                yield return new ValidationResult("Введите пароль", new string[] { "password" });
            }
            else
            {
                if (password.Length < 5 || password.Length > 15)
                {
                    yield return new ValidationResult("Пароль должен быть больше 5 и меньше 15 символов", new string[] { "password" });
                }
                //пароли совпадают
                if (password != ConfirmPassword)
                {
                    yield return new ValidationResult("Пароли не совпадают", new string[] { "ConfirmPassword" });
                }
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                yield return new ValidationResult("Введите Имя", new string[] { "name" });
            }
            else
            {
                if (name.Length <= 3 || name.Length > 15)
                {
                    yield return new ValidationResult("Имя быть больше 3 и меньше 15 символов", new string[] { "name" });
                }
                if (reg.IsMatch(name))
                {
                    yield return new ValidationResult("Символы запрещены", new string[] { "name" });
                }
            }
        }
    }
}