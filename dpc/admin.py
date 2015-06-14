from django.contrib.gis import admin

from .models import Unite_Mesure, Menaces, Caract_Menaces, Risques, Commune

class CommuneAdmin(admin.OSMGeoAdmin):
    list_display = ('commune','departemen',)
    search_fields = ('commune', 'departemen',)

admin.site.register(Unite_Mesure)
admin.site.register(Menaces)
admin.site.register(Caract_Menaces)
admin.site.register(Risques)
admin.site.register(Commune, CommuneAdmin)
