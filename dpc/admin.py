from django.contrib import admin

from .models import Menaces, Caract_Menaces, Risques, Commune

class CommuneAdmin(admin.ModelAdmin):
    list_display = ('commune','departemen',)
    search_fields = ('commune', 'departemen',)

admin.site.register(Menaces)
admin.site.register(Caract_Menaces)
admin.site.register(Risques)
admin.site.register(Commune, CommuneAdmin)
