# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models, migrations


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
        migrations.CreateModel(
            name='Unite_Mesure',
            fields=[
                ('id', models.AutoField(verbose_name='ID', serialize=False, auto_created=True, primary_key=True)),
                ('description', models.CharField(max_length=50)),
                ('isBase', models.BooleanField()),
                ('valeur_ref', models.FloatField()),
            ],
        ),
        migrations.AddField(
            model_name='caract_menaces',
            name='estEsprimee',
            field=models.ForeignKey(to='dpc.Unite_Mesure'),
        ),
    ]
