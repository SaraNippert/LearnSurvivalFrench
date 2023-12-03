using Learn_French_App.Exceptions;
using Learn_French_App.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Text;

namespace Learn_French_App.DAO
{
    public class ContentDao : IContentDao
    {
        //private string connectionString = "Data Source=PUNKINPC\\SQLEXPRESS;Initial Catalog=LearnFrenchAppDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=LearnFrenchAppDB;Integrated Security=True";

        public Content content = new Content();

        public Content GetVocab()
        {
            Content content = new Content();

            string sqlGetVocab =
                   "SELECT * FROM Vocab";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sqlGetVocab, conn))
                    {
                        //create instance of reader
                        SqlDataReader reader = cmd.ExecuteReader();

                        //todo: fix null reference of content.IntroGreetings
                        //read through database
                        while (reader.Read() == true)
                        {
                            FlashCardInfo currentFlashCard = new FlashCardInfo();

                            int currentId = Convert.ToInt32(reader["id"]);
                            currentFlashCard.ThemeId = Convert.ToInt32(reader["theme_id"]);
                            currentFlashCard.SubThemeId = Convert.ToInt32(reader["sub_theme_id"]);
                            currentFlashCard.English = Convert.ToString(reader["english"]);
                            currentFlashCard.French = Convert.ToString(reader["french"]);



                            if (currentFlashCard.ThemeId == 1 && currentFlashCard.SubThemeId == 1)
                            {
                                content.IntroGreetings.Add(currentId, currentFlashCard);
                            }
                            else if (currentFlashCard.ThemeId == 1 && currentFlashCard.SubThemeId == 2)
                            {
                                content.IntroMood.Add(currentId, currentFlashCard);
                            }
                            else if (currentFlashCard.ThemeId == 1 && currentFlashCard.SubThemeId == 3)
                            {
                                content.IntroNames.Add(currentId, currentFlashCard);
                            }
                            else if (currentFlashCard.ThemeId == 1 && currentFlashCard.SubThemeId == 4)
                            {
                                content.IntroSentences.Add(currentId, currentFlashCard);
                            }
                            else if (currentFlashCard.ThemeId == 2 && currentFlashCard.SubThemeId == 1)
                            {
                                content.PlansBase.Add(currentId, currentFlashCard);
                            }


                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException(ex.Message);
            }

            return content;

        }
    }
}
