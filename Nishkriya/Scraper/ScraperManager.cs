﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nishkriya.Models;

namespace Nishkriya.Scraper
{
    public class ScraperManager
    {
        public void Run()
        {
            using (var db = new NishkriyaContext())
            {
                var accounts = db.Accounts.Where(a => a.Active).ToList();
                var hasher = new Sha1Provider();
                var scrapers = new List<IForumScraper> {new YAFScavenger(hasher), new VBulletinScavenger()};
                scrapers.ForEach(s => s.Scrape(db));
            }
        }
    }
}