<script lang="ts">

import { Component, Vue } from 'vue-property-decorator';
import { Getter, Action, namespace } from 'vuex-class';

const AuthAction = namespace('auth', Action);
const SettingsGetter = namespace('settings', Getter);

@Component({})
export default class BaseView extends Vue {
    @SettingsGetter('getTranslate') public resx: string;
    @AuthAction('resetTimer') public resetTimer: any;

    public mounted() {
        this.resetTimer();
    }
}

</script>
