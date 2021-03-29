namespace KiipPazardzhik.Areas.Administration.ViewModels.Information.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using Ganss.XSS;

    public class AddInformationInputModel
    {
        [Required]
        [Display(Name = "Съдържание")]
        public string Description { get; set; }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);
    }
}