class Calculate

def initialize()
  
end  
  #This method will calculate the user's experience level in a skillset. This is done by leveraging
  #the time in a job related to a skill, the certifications obtained that relate to the specific 
  #skill, the degree(s) (and its level(s)), and educational publications regarding the skill. 
  #Experience is then increased by the number of points in each section. 
    
  #JobExperience = (1 Point * JobTimeInMonths) 
  #The 1 in the above equation is a weighted factor. As such, each month earns 1 point of experience to the JobExperience variable. This also applies
  #to skills that are similar.  
  
  #Degree = (StandardDegreeLengthInYears * 7 Points)
  #The Degree only counts if it is from a degree pertaining to the skill. Also, a person that spends 6 years completing a 4 year degree is still calculated as 4 * 5  
  
  #Certifications = (5 Points For Beginner Certifications, 8 Points For Intermediate Certifications, 10 Points For Advanced Certifications )
  
  #Publications = (15 Points Per Publication)  
  
      
  def skillExperience (Skill s, int months, string degExperience, string certLevel, int publications)      
    #Experience = JobExperience(OPTIONAL) + Degree(OPTIONAL) + Certifications(OPTIONAL) + Publications(OPTIONAL)
    int skillExperience = experienceFromJob(months) + degreeExperience(degExperience) + certificationExperience(certLevel) + publicationExperience(publications)
    s.setExperience(skillExperience)
    #Perhaps a return statement here? Depends on other functions' needs 
  end
  
  def experienceFromJob(int months)
    int jobExpScore = months * 1
    return jobExpScore
  end
  
  def degreeExperience(string degreeLevel)
    if (degreeLevel == "HighSchool")
      return 7
    else if(degreeLevel == "Associates")
      return (2 * 7)
    else if(degreeLevel == "Bachelors")
      return (4 * 7)
    else if(degreeLevel == "Masters" || degreeLevel == "Doctorate")
      return (6 * 7) 
  end
  
  def certificationExperience(string certLevel)
    if (certLevel == "Beginner")
      return 5
    else if(certLevel == "Intermediate")
      return 8
    else if(certLevel == "Advanced")
      return 10
  end
  
  def publicationExperience(int publications)
    int pubExpScore = publications * 15
  end
  
  
  
  
end