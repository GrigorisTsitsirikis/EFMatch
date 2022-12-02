using EFDataLibrary.DataAccess;
using EFDataLibrary.Models;
using System.Text.Json;
//using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Threading;

namespace EFMatch.InitializeData
{
    public class InitData : IInitService
    {
        private readonly MatchContext _db;
        public InitData(MatchContext db)
        {
            _db = db;
        }

        public void InitMatchData()
        {
            LoadMatchData();
        }

        private void LoadMatchData()
        {

            if (_db.Match.Count() == 0)
            {
                string file = System.IO.File.ReadAllText("MatchData.json");
                var matches = JsonSerializer.Deserialize<List<Match>>(file);
                _db.AddRange(matches);
                _db.SaveChanges();

                if (_db.MatchOdds.Count() == 0)
                {
                    string file2 = System.IO.File.ReadAllText("MatchOddsData.json");
                    var matchOdds = JsonSerializer.Deserialize<List<MatchOdds>>(file2);

                    var match = matches.FirstOrDefault();

                        foreach (var matchOdd in matchOdds)
                        {
                            matchOdd.MatchId = match.ID;
                        }
                
                    _db.AddRange(matchOdds);
                    _db.SaveChanges();
                }
            }
        }
    }
}
