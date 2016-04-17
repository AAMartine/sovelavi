from django.contrib.gis.db import models

class Batiments(models.Model):
    osm_id = models.CharField(max_length=11)
    name = models.CharField(max_length=48)
    type = models.CharField(max_length=16)
    geom = models.MultiPolygonField(srid=4326)
    objects = models.GeoManager()

    def __str__(self):
        return self.name
 
class Ressources(models.Model):
    nom = models.CharField(max_length=50)
    caracteristiques= models.ForeignKey("Caract_Menaces")
    duree = models.DurationField()

class Menaces(models.Model):
    nom = models.CharField(max_length=50)
    caracteristiques= models.ForeignKey("Caract_Menaces")
    duree = models.DurationField()
	 
class Caract_Menaces(models.Model):
    description = models.CharField(max_length=50)
	 
class Risques(models.Model):
    description = models.CharField(max_length=50)
    menaces= models.ForeignKey("Menaces")
