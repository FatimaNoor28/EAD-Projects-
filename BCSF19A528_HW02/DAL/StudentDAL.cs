using System;
using DTO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DAL
{
    public class StudentDAL : BaseDAL
    {
        public void SaveStudent(StudentDTO dto)
        {
            String JsonString = JsonSerializer.Serialize(dto);
            Save("data.txt", JsonString);
        }

        public StudentDTO getStudent()
        {
            String obj = Read("data.txt");
            if (obj == null)
            {
                return null;
            }
            StudentDTO dto = JsonSerializer.Deserialize<StudentDTO>(obj);
            return dto;
        }
    }
}
