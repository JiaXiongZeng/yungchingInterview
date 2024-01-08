using System.Diagnostics;

namespace TestPseudoEstateAPI
{
    [TestClass]
    public class UnitTestEstate
    {
        private static SwaggerClient _api;
        private static Process _process;
        static UnitTestEstate()
        {
            _api = new SwaggerClient("https://localhost:8089", new HttpClient());

            string dir = Directory.GetCurrentDirectory();
            string solutionDir = dir.Substring(0, dir.IndexOf("\\yungchingInterview")) + "\\yungchingInterview";
            string workingDir = solutionDir + "\\PseudoEstateAPI\\bin\\Debug\\net6.0";
            string fileName = "PseudoEstateAPI.exe";

            //Run API Serivce First
            _process = new Process();
            _process.StartInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                WorkingDirectory = workingDir,
                FileName = fileName
            };
            _process.Start();
        }

        [TestMethod]
        //For the sake of data integrity, the delete method can't truely delete the record from DB.
        //Check if just flaged the record as "delete."
        public async Task TestEstateDelete()
        {
            bool validation = false;
            string testId = $"PTEST{DateTime.Now.ToString("yyyyMMddHHmmssfff")}";

            var estateNew = await _api.EstatesPOSTAsync(new Estate
            {
                EstateId = testId,
                Name = "Test",
                CreateId = "TEST",
                CreateName = "TEST",
                CreateDtm = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            });

            await _api.EstatesDELETEAsync(testId);
            
            var theDeletedEstate = await _api.EstatesGETAsync(testId);
            if (theDeletedEstate != null)
            {
                if (!string.IsNullOrEmpty(theDeletedEstate.DeleteId))
                {
                    validation = true;
                }
            }

            Assert.IsTrue(validation);
        }


        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            //Remove data here when necessary
            _process.Kill();
        }
    }
}