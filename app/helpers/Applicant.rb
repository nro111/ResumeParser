#This class will hold the methods that take information from the Parser class and create an Applicant object
#for use in other parts of the system. 

#this class should place all skills the applicant has into a list
#skills in this list should be extracted individually and evaluated by the Calculate class to find skillExperience

#Use a foreach statement to find all Skill objects in applicant.skills enumerable.

#Either have Applicant class initialize Parser or use an Adapter class
#Still need to know what methods are a part of the Parser class and what values are to be returned from those methods. This is why an Adapter pattern may be needed. 

class Applicant

def initialize()
  
end
#Parser p = new Parser
 
#Regardless of how Parser is initialized, return values into the following arrays  
skills = Array.new([])  
jobs = Array.new([])
certifications = Array.new([]) 
degrees = Array.new([]) 
publications = Array.new([])

  
 #run method with foreach statement for skills. This method will iterate through each skill and decide if resume items are applicable as experience. 
 #so if a person has c# listed and is a network engineer for three years, the individual does not receive points towards the skill c#. S/he does receive that number of points towards core networking skills
 
 def calculateExperience   
   #extracts a single skill and bruteforce checks if it is similar to every job, cert, degree, or pub listed in the resume. Does this until there are no more skills left in the skills collection
   calculate = Calculate.new() 
   compare = Compare.new()
   skills.each do |skill|     
     jobs.each do |job|
       #Check to see if job is similar to the skill
        compare.similarityBetween(skill, job)     
     end     
     certifications.each do |certification|
       #Check to see if certification is similar to the skill
       compare.similarityBetween(skill, certification)
     end     
     degrees.each do |degree|
       #Check to see if degree is similar to the skill
       compare.similarityBetween(skill, degree)
     end     
     publications.each do |publication|
       #Check to see if publication is similar to the skill
       compare.similarityBetween(skill, publication)
     end     
   end   
 end
 end
