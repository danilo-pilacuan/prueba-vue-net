<template>

    <tr>

        <td><input type="text" v-model="modelDescripcion" :disabled="!habilitarGuardar"></td>

        <td><input type="text" v-model="modelLugar" :disabled="!habilitarGuardar"></td>

        <td><input type="number" v-model="modelPrecio" :disabled="!habilitarGuardar"></td>

        <td><input type="date" v-model="modelFecha" :disabled="!habilitarGuardar"></td>
        <td style="display: flex; flex-direction: column;">
            <input type="button" :class="!habilitarGuardar ? 'btnEvento' : 'btnDisabled'" value="Actualizar"
                @click="handleActualizar" :disabled="habilitarGuardar">
            <input type="button" :class="habilitarGuardar ? 'btnEvento' : 'btnDisabled'" value="Guardar"
                @click="handleGuardar" :disabled="!habilitarGuardar">
            <input type="button" class="btnEvento" value="Eliminar" @click="handleBorrar">
        </td>
    </tr>
</template>

<script setup lang="ts">

//#region imports


//#endregion imports


//#region props


export interface TEventoComponentProps {
    eventoProps: TEvento
}

// eslint-disable-next-line @typescript-eslint/no-unused-vars
const props = withDefaults(defineProps<TEventoComponentProps>(), {

});

//#endregion props

//#region Computed

//#endregion Computed


//#region emits
const emit = defineEmits<{
    (e: 'datosActualizados'): void
}>()

//#endregion emits



//#region Data

const modelDescripcion = ref<string>('')
const modelLugar = ref<string>('')
const modelPrecio = ref<number>(0)
const modelFecha = ref<string>()

const habilitarGuardar = ref<boolean>(false)

//#endregion Data


//#region methods

const handleActualizar = () => {
    habilitarGuardar.value = true
}
const handleBorrar = () => {
    eliminarEvento()
}

const handleGuardar = () => {
    const nuevoEvento =
        {
            id: 0,
            descripcionEvento: modelDescripcion.value,
            lugarEvento: modelLugar.value,
            precioEvento: modelPrecio.value,
            fechaEvento: modelFecha.value
        } as TEvento
    actualizarEvento(nuevoEvento)

}



const actualizarEvento = async (nuevoEvento: TEvento) => {
    try {

        const url = 'https://localhost:7157/api/Evento/' + props.eventoProps.id;

        const requestOptions: RequestInit = {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(nuevoEvento)
        };


        const response = await fetch(url, requestOptions);


        if (!response.ok) {
            throw new Error('La solicitud no pudo ser completada.');
        }


        //const responseData = await response.json();
        habilitarGuardar.value = false
        emit('datosActualizados')

    } catch (error: unknown) {

        console.error('Error:', error);
        const err = error as Error;

        console.log('Error:\n' + err.message);
    }
}

const eliminarEvento = async () => {
    try {

        const url = 'https://localhost:7157/api/Evento/' + props.eventoProps.id;

        const requestOptions: RequestInit = {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            },

        };


        const response = await fetch(url, requestOptions);


        if (!response.ok) {
            throw new Error('La solicitud no pudo ser completada.');
        }


        const responseData = await response.json();

        emit('datosActualizados')



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

    modelDescripcion.value = props.eventoProps.descripcionEvento;
    modelLugar.value = props.eventoProps.lugarEvento;
    modelPrecio.value = props.eventoProps.precioEvento;
    const fechaEvento = new Date(props.eventoProps.fechaEvento);
    const year = fechaEvento.getFullYear();
    const month = (fechaEvento.getMonth() + 1).toString().padStart(2, '0'); // El mes está basado en 0, por eso sumamos 1
    const day = fechaEvento.getDate().toString().padStart(2, '0');
    modelFecha.value = `${year}-${month}-${day}`;
    console.log('modelFecha.value')
    console.log(modelFecha.value)
});



//#endregion Lifecycle Hooks

</script>

<script lang="ts">
import type { TEvento } from '@/types/TypesDefinition';
import { defineComponent, onMounted, ref } from 'vue'

export default defineComponent({
    name: 'EventoComponent'
})
</script>

<style>
.eventoComponent {
    display: flex;
    width: 100%;
}

.btnEvento {
    height: 30px;
    /* Tamaño fijo para el botón */
    width: 100px;
    /* Ancho fijo para el botón */
    background-color: #007bff;
    color: #fff;
    border: none;
    border-radius: 5px;
    margin: 5px;
}

.btnDisabled {
    height: 30px;
    /* Tamaño fijo para el botón */
    width: 100px;
    /* Ancho fijo para el botón */
    background-color: #939ba3;
    color: #fff;
    border: none;
    border-radius: 5px;
    margin: 5px;
}
</style>