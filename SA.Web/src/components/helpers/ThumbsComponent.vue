<template>
  <div class="thumbs-component">
    <v-layout row wrap v-if="user.isFeePayed && user.isAuthenticated && isBidding(record.biddingUserIds)">
        <v-flex xs12 class="text-xs-right">
            <v-tooltip top v-if="user.userId === record.winningUserId">
                <v-btn icon slot="activator" color="white">
                    <v-icon small color="green" style="cursor: pointer">thumb_up</v-icon>
                </v-btn>
                <span>{{ resx('winning') }} </span>
            </v-tooltip>
            <v-tooltip top v-else>
                <v-btn icon slot="activator" color="white">
                    <v-icon small color="red" style="cursor: pointer">thumb_down</v-icon>
                </v-btn>
                <span>{{ resx('notWinning') }} </span>
            </v-tooltip>
        </v-flex>
    </v-layout>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Watch } from 'vue-property-decorator';
import { Getter, namespace } from 'vuex-class';

import { AuthUser, RecordTableDto } from './../../poco';

import BaseComponent from '../BaseComponent.vue';

const AuthGetter = namespace('auth', Getter);

@Component({})
export default class ThumbsComponent extends BaseComponent {
    @Prop({ default: undefined })
    private record: RecordTableDto;

    @AuthGetter('getCurrentLoggedUser')
    private user: AuthUser;

    private isBidding(biddingIds: number[]): boolean {
        return biddingIds.indexOf(this.user.userId) !== -1;
    }
}
</script>
