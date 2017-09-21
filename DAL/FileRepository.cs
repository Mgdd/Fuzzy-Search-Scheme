using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class FileRepository
    {
        public static void InsertFile(this File file, SqlCommand cmd)
        {
            cmd.CommandText = "INSERT INTO FileIndexing (FileIndex ,Title,FileContent,Type,Url,UserName)" +
                            "VALUES (@FileIndex,@Title,@FileContent,@Type,@Url,@UserName)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@FileIndex", file.FileIndex);
            cmd.Parameters.AddWithValue("@Title", file.Title);
            cmd.Parameters.AddWithValue("@FileContent", file.FileContent);
            cmd.Parameters.AddWithValue("@Type", file.Type);
            cmd.Parameters.AddWithValue("@Url", file.Url);
            cmd.Parameters.AddWithValue("@UserName", file.UserName);
            cmd.ExecuteNonQuery();
        }
        public static void InsertKeyword(this List<Keyword> lsKeywords, SqlCommand cmd)
        {
            foreach (var Keywords in lsKeywords)
            {
                cmd.CommandText = "INSERT INTO KeywordIndexing (Id,Keyword)" +
                            "VALUES (@Id,@Keyword)"+
                            " INSERT INTO Ranking (KeyWordId,FileId,Rank)" +
                            " VALUES (@Id,@FileIndex,@Rank)";
                /*cmd.CommandText = "INSERT INTO KeywordIndexing (Id,FileIndex ,Keyword,Rank)" +
                            "VALUES (@Id,@FileIndex,@Keyword,@Rank)";*/

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id", Keywords.Id);
                cmd.Parameters.AddWithValue("@FileIndex", Keywords.FileIndex);
                cmd.Parameters.AddWithValue("@Keyword", Keywords.KeyWord);
                cmd.Parameters.AddWithValue("@Rank", Keywords.Rank);
                //Execute Command
                cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteFile(this File file, SqlCommand cmd)
        {
            cmd.CommandText = "delete FileIndexing where FileIndex=@FileIndex";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@FileIndex", file.FileIndex);
            cmd.ExecuteNonQuery();
        }
        public static void DeleteKeywordIndexing(int KeywordIndexing, SqlCommand cmd)
        {
            cmd.CommandText = "delete KeywordIndexing where Id=@Id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Id", KeywordIndexing);
            cmd.ExecuteNonQuery();
        }
    }
}
