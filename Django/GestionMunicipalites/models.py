from django.contrib.gis.db import models

class CollectivitesTerritoriales(models.Model):
    id_com = models.IntegerField()
    commune = models.CharField(max_length=254)
    id_dep = models.IntegerField()
    departemen = models.CharField(max_length=254)
    shape_leng = models.FloatField()
    latitude = models.FloatField()
    longitude = models.FloatField()
    shape_le_1 = models.FloatField()
    shape_area = models.FloatField()
    geom = models.MultiPolygonField()
    objects = models.GeoManager()

    def __str__(self):
        return self.commune
 
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
