from django.contrib.gis.utils import LayerMapping

from .models import Commune

commune_mapping = {
    'id_com' : 'id_com',
    'commune' : 'commune',
    'id_dep' : 'id_dep',
    'departemen' : 'departemen',
    'shape_leng' : 'shape_leng',
    'latitude' : 'latitude',
    'longitude' : 'longitude',
    'shape_le_1' : 'shape_le_1',
    'shape_area' : 'shape_area',
    'geom' : 'POLYGON',
}

lm = LayerMapping(Commune, '/Users/ortelius/projects/haiti/admin/hti_boundaries_communes_adm2_cnigs_polygon.shp', commune_mapping)
lm.save(verbose=True)
