﻿namespace WebApplication6.Dto;

public class PatientDto
{
    public class Get
    {
        public int IdPatient { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
    
        public DateTime Birthdate { get; set; }
    }
}