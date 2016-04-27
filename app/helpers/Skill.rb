#this is the class that interacts with the database and creates a skill object in working memory
#This class uses accessor and mutator methods to help determine skill experience 
class Skill
  skillExperience = 0
  
  def setExperience(experienceLevel)
    skillExperience = experienceLevel
  end
  
  def getExperience() 
    return skillExperience 
  end
end
