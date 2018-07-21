<script lang="ts">

import { Component, Vue } from 'vue-property-decorator';
import { State, Getter, Action, namespace } from 'vuex-class';
import { SettingsState } from '@/store/types';

const SettingsGetter = namespace('settings', Getter);

@Component({})
export default class BaseComponent extends Vue {

  @State('settings') public settings: SettingsState;
  @SettingsGetter('getTranslate') public resx: string;
}
</script>
