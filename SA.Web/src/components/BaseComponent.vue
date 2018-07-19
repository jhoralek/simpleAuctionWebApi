<script lang="ts">

import { Component, Vue } from 'vue-property-decorator';
import { State, Getter } from 'vuex-class';
import { SettingsState } from '@/store/types';

const namespace: string = 'settings';

@Component({})
export default class BaseComponent extends Vue {

  @State('settings') public settings: SettingsState;
  @Getter('getTranslate', { namespace }) public resx: string;
}
</script>
