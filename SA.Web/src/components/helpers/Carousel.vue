<template>
</template>

<script lang="ts">

import { Component, Prop } from 'vue-property-decorator';
import BaseComponent from '../BaseComponent.vue';

@Component({})
export default class Carousel<T> extends BaseComponent {
    @Prop({default: undefined}) private data: T;
}

</script>