<template>
    <div>
        <!--<file-explorer :folders="folders"
                       :level="1"
                       :selectable="false"
                       :parentView="`file-server`"
                       ref="fileExplorer"></file-explorer>-->
        <v-container>
            <div class="headline deep-orange--text">
                Video Player
            </div>
            <div>
                <v-select v-model="selected"
                          :items="fileList"
                          label="Select a video here"
                          ></v-select>
                <video-player :url="getUrl" :type="getType" ref="v-player"></video-player>
            </div>
            <!--<div class="headline deep-orange--text text--darken-2">
                Downloads
            </div>
            <v-list-tile v-for="(item, i) in fileList" :key="i">
                <v-list-tile-content class="title">
                    <a :href="getDownloadPath(item)" class="orange--text text--darken-1" download>{{ item }}</a>
                </v-list-tile-content>
            </v-list-tile>-->
        </v-container>
    </div>
</template>

<script>
    import FileExplorer from '../modules/file-explorer'
    import VideoPlayer from '../modules/video-player'
    import axios from '../../axios'

    let path = process.env.API_URL;

    export default {
        data() {
            return {
                //folders: [
                //    { text: 'Random Files', value: 'general_files' },
                //]
                fileList: [],
                basepath: path,
                selected: '',
            }
        },
        components: {
            "file-explorer": FileExplorer,
            "video-player": VideoPlayer,
        },
        created() {
            this.getData();
        },
        mounted() {
            //this.$refs.fileExplorer.setSelectedFolder(this.folders[0].value);
            //this.$refs.fileExplorer.loadDirectory();
        },
        computed: {
            getUrl() {
                if (typeof this.selected === 'undefined' || this.selected === null || this.selected === '')
                    return "";

                return `${path}/videos/${encodeURI(this.selected)}`;
            },
            getType() {
                if (typeof this.selected === 'undefined' || this.selected === null || this.selected === '')
                    return "";

                if (!this.selected.includes('.'))
                    return "";

                let index = this.selected.lastIndexOf('.');
                let extension = this.selected.slice(index);

                switch (extension) {
                    case '.mkv':
                        return 'video/webm';
                    case '.avi':
                        return 'video/x-msvideo';
                    case '.mpeg':
                    case '.mpg':
                        return 'video/mp4';
                    case '.wmv':
                        return 'video/x-ms-wmv';

                    case '.mp3':
                        return 'audio/mpeg';
                    default:
                        return '';
                }
            },
        },
        watch: {
            //selected: function () {
            //    this.$refs.form.submit();
            //}
        },
        methods: {
            async getData() {
                await axios.get('api/file-server/list')
                    .then(resp => {
                        this.$_console_log(resp);
                        this.fileList = resp.data;
                    }).catch(() => this.$_console_log('Failed to get list of file server files'));
            },
            getLinkPath: function (item) {
                return `${path}/Home/DownloadFile?fileName=${item}`;
            },
            getDownloadPath(file) {
                return path + '/Home/DownloadFile?fileName=' + file;
            },
        }
    }
</script>
