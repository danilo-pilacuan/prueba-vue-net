<template>
    <h1>Eventos</h1>
    <div class="controlesEventos">
        <input type="button" style="background-color: greenyellow;" value="Crear" :disabled="!deshabilitarControles"
            @click="handleCrear">
        <div class="inputPropsEvento">
            <label for="descripcion">Descripción</label>
            <input type="text" name="descripcion" placeholder="Ingrese descripcion" :disabled="deshabilitarControles"
                v-model="inputDescripcion">
        </div>
        <div class="inputPropsEvento">
            <label for="lugar">Lugar</label>
            <input type="text" name="lugar" placeholder="Ingrese lugar" :disabled="deshabilitarControles"
                v-model="inputLugar">
        </div>
        <div class="inputPropsEvento">
            <label for="precio">Precio</label>
            <input type="text" name="precio" placeholder="Ingrese precio" :disabled="deshabilitarControles"
                v-model="inputPrecio">
        </div>
        <div class="inputPropsEvento">
            <label for="fecha">Fecha</label>
            <input type="date" name="fecha" placeholder="Ingrese fecha" :disabled="deshabilitarControles"
                v-model="inputFecha">
        </div>
        <input type="button" style="background-color: greenyellow;" value="Guardar" :disabled="deshabilitarControles"
            @click="handleGuardar">
    </div>
    <div class="listaEventosComponent">
        <table class="tablaEventos">
            <thead>
                <tr>
                    <th>Descripción</th>
                    <th>Lugar</th>
                    <th>Precio</th>
                    <th>Fecha</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody v-for="(eventoItem, index) in listaEventos" :key="index">
                <EventoComponent :eventoProps="eventoItem" @datosActualizados="handleEventoActualizado" />
            </tbody>
        </table>
        <div class="paginas">
            <a rel="stylesheet" href=""
                v-for="(valor, index) in Array.from({ length: numPaginas }, (_, index) => index + 1)" :key="index"> {{
                    valor }}</a>
        </div>
    </div>
</template>

<script setup lang="ts">

//#region imports

import type { TEvento } from '@/types/TypesDefinition';
import EventoComponent from './EventoComponent.vue';

//#endregion imports


//#region props

//   export interface TCodeBlockProps {
//     codeBlockProps: TCodeBlock
//   }

//   const props = withDefaults(defineProps<TCodeBlockProps>(), {

//   });

//#endregion props

//#region Computed

//#endregion Computed


//#region emits


//#endregion emits


//#region Data

const listaEventos = ref<TEvento[]>();

const deshabilitarControles = ref<boolean>(true);

const inputDescripcion = ref<string>('');
const inputLugar = ref<string>('');
const inputPrecio = ref<string>('');
const inputFecha = ref<string>('');

const pagina = ref<number>(1);
const numPaginas = ref<number>(1);

//#endregion Data


//#region methods

const handleCrear = () => {
    deshabilitarControles.value = false;
}

const handleEventoActualizado = () => {
    obtenerEventos()
}

const handleGuardar = () => {
    const nuevoEvento =
        {
            id: 0,
            descripcionEvento: inputDescripcion.value,
            lugarEvento: inputLugar.value,
            precioEvento: parseFloat(inputPrecio.value),
            fechaEvento: inputFecha.value
        } as TEvento
    agregarEvento(nuevoEvento)
    inputDescripcion.value = ''
    inputLugar.value = ''
    inputPrecio.value = ''
    inputFecha.value = ''
}

const obtenerEventos = async () => {
    try {

        const url = 'https://localhost:7157/api/Evento/1/1';


        const response = await fetch(url);


        if (!response.ok) {
            throw new Error('La solicitud no pudo ser completada.');
        }


        const responseData = await response.json();
        const eventos = responseData.eventos
        console.log('eventos')
        console.log(eventos)
        listaEventos.value = eventos.map((eventoItem: { id: number; descripcionEvento: string; lugarEvento: string; precioEvento: number; fechaEvento: string; }) => {



            return {
                id: eventoItem.id,
                descripcionEvento: eventoItem.descripcionEvento,
                lugarEvento: eventoItem.lugarEvento,
                precioEvento: eventoItem.precioEvento,
                fechaEvento: eventoItem.fechaEvento
            } as TEvento
        })


        numPaginas.value = responseData.paginas

        console.log('listaEventos.value')
        console.log(listaEventos.value)

    } catch (error: unknown) {

        console.error('Error:', error);
        const err = error as Error;

        console.log('Error:\n' + err.message);
    }
}

const agregarEvento = async (nuevoEvento: TEvento) => {
    try {

        const url = 'https://localhost:7157/api/Evento';

        const requestOptions: RequestInit = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(nuevoEvento)
        };


        const response = await fetch(url, requestOptions);


        if (!response.ok) {
            throw new Error('La solicitud no pudo ser completada.');
        }


        const responseData = await response.json();

        obtenerEventos()


        console.log('listaEventos.value')
        console.log(listaEventos.value)

    } catch (error: unknown) {

        console.error('Error:', error);
        const err = error as Error;

        console.log('Error:\n' + err.message);
    }
}


//#endregion methods

//#region watchers



//#endregion watchers


//#region Lifecycle Hooks
onMounted(() => {

    obtenerEventos()

});



//#endregion Lifecycle Hooks

</script>

<script lang="ts">
import { defineComponent, onMounted, ref } from 'vue';

export default defineComponent({
    name: 'ListaEventosComponent'
})
</script>

<style>
.listaEventosComponent {
    display: flex;
    flex-direction: column;
    width: 100%;
}


.tablaEventos {
    border-collapse: collapse;
    width: 100%;
}

.tablaEventos th,
.tablaEventos td {
    border: 1px solid #dddddd;
    text-align: left;
    padding: 8px;
    height: 120px;
}



.tablaEventos th {
    font-weight: bold;
}

.controlesEventos {
    display: flex;
    background-color: #127dfc;
    color: white;
}
</style>