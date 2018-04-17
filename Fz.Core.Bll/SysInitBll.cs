using Fz.Core.VModel.SyInit;
using FzDatabase.Basic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.Bll
{
    public class SysInitBll
    {
        public static InitForm GetInitForm() {
           
            using (var db = new fz_basicEntities())
            {
                InitForm init = new InitForm();
                sy_init syinit = db.sy_init.FirstOrDefault();
                if(syinit != null)
                {
                    init.SchoolName = syinit.SchoolName;
                    init.AuthMessage = syinit.AuthMessage;
                }             
                List<dict_subject> subjectlist = db.dict_subject.Where(w=>w.IsEnabled).OrderBy(o=>o.Sort).ToList();
                if(subjectlist != null && subjectlist.Count > 0)
                {
                    init.choEdi = new List<EdiSubGrid>(); 
                    foreach(dict_subject subject in subjectlist)
                    {
                        EdiSubGrid esg = new EdiSubGrid();
                        esg.EdiList = db.dict_edition_and_subject.Where(w => w.dict_subject.Id == subject.Id).Select(s => new Edition
                        {
                            EdiId = s.dict_edition.Id,
                            EdiName = s.dict_edition.Name,
                            IsEnabled = s.IsEnabled
                        }).ToList();
                        esg.SubId = subject.Id;
                        esg.SubName = subject.Name;
                        init.choEdi.Add(esg);
                    }
                }
                return init;
            }        
        }

        public static bool SaveInitForm(InitForm initform)
        {
            using (var db = new fz_basicEntities())
            {
                int tempeId;
                dict_edition_and_subject edisub;
                List<dict_edition_and_subject> edisubList = db.dict_edition_and_subject.ToList();
                foreach(dict_edition_and_subject esub in edisubList) {
                    esub.IsEnabled = false;
                }
                if (initform.chooseEdis1 != null)
                {
                    for (int i = 0; i < initform.chooseEdis1.Length; i++)
                    {
                        tempeId =int.Parse(initform.chooseEdis1[i]);
                        edisub = db.dict_edition_and_subject.Where(w => w.SubjectId == 1 && w.EditionId == tempeId).FirstOrDefault();
                        edisub.IsEnabled = true;
                    }

                }
                if (initform.chooseEdis2 != null)
                {
                    for (int i = 0; i < initform.chooseEdis2.Length; i++)
                    {
                        tempeId = int.Parse(initform.chooseEdis2[i]);
                        edisub = db.dict_edition_and_subject.Where(w => w.SubjectId == 2 && w.EditionId == tempeId).FirstOrDefault();
                        edisub.IsEnabled = true;
                    }

                }
                if (initform.chooseEdis3 != null)
                {
                    for (int i = 0; i < initform.chooseEdis3.Length; i++)
                    {
                        tempeId = int.Parse(initform.chooseEdis3[i]);
                        edisub = db.dict_edition_and_subject.Where(w => w.SubjectId == 3 && w.EditionId == tempeId).FirstOrDefault();
                        edisub.IsEnabled = true;
                    }

                }               
                db.sy_init.RemoveRange(db.sy_init);
                sy_init init = new sy_init();
                init.Id = System.Guid.NewGuid().ToString();
                init.SchoolName = initform.SchoolName;
                init.AuthMessage = initform.AuthMessage;
                db.sy_init.Add(init);
                return db.SaveChanges() > 0;

            }
        }
    }
}
