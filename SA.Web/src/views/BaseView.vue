<script lang="ts">

import { Component, Vue } from 'vue-property-decorator';
import { Getter, Action, namespace } from 'vuex-class';

const AuthAction = namespace('auth', Action);
const SettingsGetter = namespace('settings', Getter);
const SettingsAction = namespace('settings', Action);

@Component({})
export default class BaseView extends Vue {
    @SettingsGetter('getTranslate')
    public resx: string;
    @AuthAction('resetTimer')
    public resetTimer: any;

    @SettingsAction('setIsMobile')
    private setDevice: any;

    public mounted() {
        this.setDevice();
        this.resetTimer();
    }
}

</script>
