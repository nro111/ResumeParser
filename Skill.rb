#this is the class that interacts with the database and creates a skill object in working memory
#This class uses accessor and mutator methods to help determine skill experience 
int skillExperience = 0
def initialize()
  
end

def setExperience(int experienceLevel)
	skillExperience = experienceLevel
end

def getExperience()	
	return skillExperience 
end