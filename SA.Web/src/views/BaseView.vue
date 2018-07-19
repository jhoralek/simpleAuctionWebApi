<script lang="ts">

import { Component, Vue } from 'vue-property-decorator';
import { Getter, State, Action } from 'vuex-class';

const namespace: string = 'settings';

@Component({})
export default class BaseView extends Vue {
    @Getter('getTranslate', { namespace }) public resx: string;
}

</script>
