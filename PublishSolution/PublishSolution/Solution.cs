using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.Surviveplus.RegularExpressionQuery;

namespace PublishSolution
{
    public class Solution
    {
        public static async Task CopyAsync(CopySolutionSettings settings)
        {
            await Task.Run(() => {

                var from = new System.IO.DirectoryInfo(settings.FromFolder);
                var to = new System.IO.DirectoryInfo(System.IO.Path.Combine(settings.ToFolder, from.Name));

                if (from.Exists == false) throw new Exception("no exist from");
                if (to.Exists) throw new Exception("exist to");


                var query =
                    from.Query()
                        .WhereExtensionNotMatch(@"\.(vspscc|vssscc)")
                        .WhereRelativePathNotMatch(@"^(TestResults|\.vs)")
                        .WhereRelativePathNotMatch(@"\\(bin|obj)\\");

                //foreach (var item in query)
                //{
                //	Debug.WriteLine(item.RelativePath);
                //}

                var results =
                    query.ToCopy(to, false);

                results
                    .WhereExtensionMatch(@"\.sln")
                    .Replace(
                        @"(?<tfvc>\tGlobalSection\(TeamFoundationVersionControl\)(.+)\tEndGlobalSection)",
                        new { tfvc = "" },
                        System.Text.RegularExpressions.RegexOptions.Singleline);

                results
                    .WhereExtensionMatch(@"\.(csproj|vbproj|sqlproj)")
                    .RemoveMatchedLines(
                        @"(?<sak>\<(SccProjectName|SccLocalPath|SccAuxPath|SccProvider)\>SAK\<\/(SccProjectName|SccLocalPath|SccAuxPath|SccProvider)\>)"
                    );

                results
                    .WhereExtensionMatch(@"\.vdproj")
                    .RemoveMatchedLines(
                        "(?<sak>\"(SccProjectName | SccLocalPath | SccAuxPath | SccProvider)\" = \"8:SAK\")"
                    );

            });

        } // end sub

    } // end class
} // end namespace
