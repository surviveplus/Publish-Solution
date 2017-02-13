using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishSolution
{
    public class CopySolutionSettings : ViewModelBase
    {
        public CopySolutionSettings()
        {
            this.FromFolder = null;
            this.ToFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        /// <summary>
        /// Backing field of FromFolder property.
        /// </summary>
        private String valueOfFromFolder;

        /// <summary>
        /// Gets or sets folder path to copy from.
        /// </summary>
        [Required]
        public String FromFolder
        {
            get
            {
                return this.valueOfFromFolder;
            } // end get
            set
            {
                this.SetProperty(ref this.valueOfFromFolder, value);
            } // end set
        } // end property

        /// <summary>
        /// Backing field of ToFolder property.
        /// </summary>
        private String valueOfToFolder;


        /// <summary>
        /// Gets or sets folder path to copy to.
        /// </summary>
        [Required]
        public String ToFolder
        {
            get
            {
                return this.valueOfToFolder;
            } // end get
            set
            {
                this.SetProperty(ref this.valueOfToFolder, value);
            } // end set
        } // end property 
    }
}
