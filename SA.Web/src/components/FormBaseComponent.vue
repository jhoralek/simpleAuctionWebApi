<script lang="ts">

import { Component, Vue } from 'vue-property-decorator';
import { State, Getter, Action, namespace } from 'vuex-class';

import BaseComponent from '@/components/BaseComponent.vue';
import { SettingsState } from '@/store/types';
import Validation from '@/validation';

const SettingsAction = namespace('settings', Action);

@Component({})
export default class FormBaseComponent extends BaseComponent {
    @SettingsAction('changeFormView') public changeFormView: any;

    public updated() {
        this.changeFormView(this.$el.className);
    }

    public mounted() {
        this.changeFormView(this.$el.className);

        const attributes = Validation
            .loadValidationAttributes(
                this.settings.currentForm,
                this.settings.language);

        if (attributes) {
            this.$validator.localize(this.settings.language, attributes);
        }
        this.$validator.localize(this.settings.language);
    }
}
</script>