using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademy.API.ViewModel.Request
{
    public class AlbumRequest : IValidatableObject
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Band { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Backdrop { get; set; }

        [Required]
        public List<MusicRequest> Musics { get; set; }

        //Metodo para validar se a lista de musica não é vazia
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();
            //Valida lista vazia
            if (this.Musics == null)
                yield return new ValidationResult("Album must contain at least one music");

            //Valida se tem pelo menos 1 item na lista 
            if (this.Musics.Any() == false)
                yield return new ValidationResult("Album  must contain at least one music");

            //Valida as propriedades do objeto Musica
            foreach (var item in this.Musics)
            {
                if (Validator.TryValidateObject(item, new ValidationContext(item), result) == false)
                    yield return result.First();

            }
        }
    }
}
