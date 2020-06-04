<template>
    <form enctype="multipart/form-data" novalidate v-if="isInitial || isSaving">
    <h1>{{ title }}</h1>
    <div class="dropbox">
        <input
            type="file"
            multiple
            :name="name"
            :disabled="isSaving"
            @change="filesChange($event.target.name, $event.target.files);
            fileCount = $event.target.files.length"
            accept="image/*"
            class="input-file">
        <p v-if="isInitial" v-html="resx('uploadFiles')"></p>
        <p v-if="isSaving">
            {{ fileCountInfo(fileCount) }}
        </p>
    </div>
    </form>
</template>

<script lang="ts">

import {  Prop, Component } from 'vue-property-decorator';
import { Action, namespace } from 'vuex-class';

import Helpers from './../../helpers';
import BaseComponent from '@/components/BaseComponent.vue';

const RecordAction = namespace('record', Action);
const STATUS_INITIAL = 0;
const STATUS_SAVING = 1;
const STATUS_SUCCESS = 2;
const STATUS_FAILED = 3;

@Component({})
export default class FileUploadComponent extends BaseComponent {
    @Prop({default: 'files'})
    private name: string;
    @Prop({default: 'Upload files'})
    private title: string;

    @RecordAction('uploadFiles')
    private upload: any;

    private uploadedFiles: any[] = [];
    private currentStatus: number = null;
    private uploadError: any = null;

    private filesChange(fieldName, fileList): void {
        const formData: FormData = new FormData();

        if (!fileList.length) {
            return;
        }

        Array.from(Array(fileList.length).keys())
            .map((x) => {
                formData.append(fieldName, fileList[x], fileList[x].name);
            });

        this.save(formData);
    }

    get isInitial(): boolean {
        return this.currentStatus === STATUS_INITIAL;
    }

    get isSaving(): boolean {
        return this.currentStatus === STATUS_SAVING;
    }

    get isSuccess(): boolean {
        return this.currentStatus === STATUS_SUCCESS;
    }

    get isFailed(): boolean {
        return this.currentStatus === STATUS_FAILED;
    }

    private mounted() {
        this.reset();
    }

    private fileCountInfo(fileCount: number): string {
        if (fileCount === undefined) {
            fileCount = 0;
        }
        return this.settings.resource.uploadingFiles.replace('{0}', fileCount.toString());
    }

    private reset(): void {
        this.currentStatus = STATUS_INITIAL;
        this.uploadedFiles = [];
        this.uploadError = null;
    }

    private save(formData: FormData): void {
        this.currentStatus = STATUS_SAVING;

        this.upload(formData).then((response) => {
            this.uploadedFiles = response;
            this.currentStatus = STATUS_SUCCESS;
            this.$emit('files', this.uploadedFiles);

            this.reset();
        })
        .catch((error) => {
            this.uploadError = error.response;
            this.currentStatus = STATUS_FAILED;
        });
    }
}

</script>

<style>
.dropbox {
    outline: 2px dashed grey; /* the dash box */
    outline-offset: -10px;
    background: lightcyan;
    color: dimgray;
    padding: 10px 10px;
    min-height: 200px; /* minimum height */
    position: relative;
    cursor: pointer;
  }

  .input-file {
    opacity: 0; /* invisible but it's there! */
    width: 100%;
    height: 200px;
    position: absolute;
    cursor: pointer;
  }

  .dropbox:hover {
    background: lightblue; /* when mouse over to the drop zone, change color */
  }

  .dropbox p {
    font-size: 1.2em;
    text-align: center;
    padding: 50px 0;
  }
  </style>
