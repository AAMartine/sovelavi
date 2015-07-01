# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models, migrations
import django.contrib.gis.db.models.fields


class Migration(migrations.Migration):

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='Caract_Menaces',
            fields=[
                ('id', models.AutoField(verbose_name='ID', serialize=False, auto_created=True, primary_key=True)),
                ('description', models.CharField(max_length=50)),
            ],
        ),
        migrations.CreateModel(
            name='Commune',
            fields=[
                ('id', models.AutoField(verbose_name='ID', serialize=False, auto_created=True, primary_key=True)),
                ('id_com', models.IntegerField()),
                ('commune', models.CharField(max_length=254)),
                ('id_dep', models.IntegerField()),
                ('departemen', models.CharField(max_length=254)),
                ('shape_leng', models.FloatField()),
                ('latitude', models.FloatField()),
                ('longitude', models.FloatField()),
                ('shape_le_1', models.FloatField()),
                ('shape_area', models.FloatField()),
                ('geom', django.contrib.gis.db.models.fields.MultiPolygonField(srid=4326)),
            ],
        ),
        migrations.CreateModel(
            name='Menaces',
            fields=[
                ('id', models.AutoField(verbose_name='ID', serialize=False, auto_created=True, primary_key=True)),
                ('nom', models.CharField(max_length=50)),
                ('duree', models.DurationField()),
                ('caracteristiques', models.ForeignKey(to='dpc.Caract_Menaces')),
            ],
        ),
        migrations.CreateModel(
            name='Risques',
            fields=[
                ('id', models.AutoField(verbose_name='ID', serialize=False, auto_created=True, primary_key=True)),
                ('description', models.CharField(max_length=50)),
                ('menaces', models.ForeignKey(to='dpc.Menaces')),
            ],
        ),
    ]
