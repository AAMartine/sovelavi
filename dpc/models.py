from django.db import models


 
class Unite_Mesure(models.model):
     description = models.CharField(max_length=50)	 
	 isBase = models.BooleanField()
	 ref = models.ForeignKey(Unite_Mesure)
	 valeur_ref = models.DecimalField()
	 
class Menaces(models.model):
     nom = models.CharField(max_length=50)
     caracteristiques= models.ForeignKey("Caract_Menaces")
	 duree = models.DurationField()
	 
class Caract_Menaces(models.model):
     description = models.CharField(max_length=50)	 
	 estEsprimee = models.ForeignKey(Unite_Mesure)
	 
class Risques(models.model):
     description = models.CharField(max_length=50)
     menaces= models.ForeignKey("Menaces")
	 
	  