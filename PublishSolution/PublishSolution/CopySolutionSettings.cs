using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishSolution
{
    public class CopySolutionSettings : ViewModelBase
    {
        /// <summary>
        /// Backing field of FromFolder property.
        /// </summary>
        private String valueOfFromFolder;

        /// <summary>
        /// Gets or sets folder path to copy from.
        /// </summary>
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
