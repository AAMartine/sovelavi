import os
from django.contrib.gis.utils import LayerMapping
from .models import Batiments
batiments_mapping = {
    'osm_id' : 'osm_id',
    'name' : 'name',
    'type' : 'type',
    'geom' : 'MULTIPOLYGON',
}
batiments_shp = os.path.abspath(os.path.join(os.path.dirname(__file__), 'haiti-geo', 'buildings.shp'))

def run(verbose=False):
    lm = LayerMapping(Batiments, batiments_shp, batiments_mapping,
                      transform=False, encoding='UTF-8')

    lm.save(strict=True, verbose=verbose)